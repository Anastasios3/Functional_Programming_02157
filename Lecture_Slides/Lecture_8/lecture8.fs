// Mini-Compiler

(* 1. Type Exp for expressions:
- integer constants (constructor C), e.g., C 3
- variables (constructor V), e.g., V "x"
- operations for addition of two expression 
  (constructor Add), e.g. Add (C 3, V "x")
- similar Sub
- change sign of an expression 
  (constructor Minus), e.g. Minus (V "x")
- absolute value of an expression 
  (constructor Abs), e.g. Abs (V "x")
*)

type Exp = | C of int
           | V of string
           | Add of Exp*Exp
           | Mul of Exp*Exp
           | Sub of Exp*Exp
           | Minus of Exp
           | Abs of Exp
           | Let of string*Exp*Exp

type Environment = Map<string,int>

let env = Map.ofList [("x",3);("y",-3)]

// |-7|+(x-(-(2+y)))
let example = 
  Add(Abs(Minus(C 7)), 
      Sub(V "x", Minus(Add(C 2, V "y"))))

//    x + (let y=x+2 in |y|)
// =  x + |x+2|
let examplewithlet = 
  Add(V "x",
      Let("y",Add (V "x", C 2), Abs (V "y")))

// sem : Environment -> Exp -> int
let rec sem env = function 
  | C i -> i
  | V x -> Map.find x env
  | Add (e1,e2) -> sem env e1 + sem env e2
  | Mul (e1,e2) -> sem env e1 * sem env e2
  | Sub (e1,e2) -> sem env e1 - sem env e2
  | Minus e -> - (sem env e)
  | Abs e -> abs (sem env e)
  | Let (v,e1,e2) -> 
      let i=sem env e1
      let env' = Map.add v i env
      sem env' e2


let test = sem env example

let testlet = sem env examplewithlet

type BExp = 
 | TT
 | FF
 | Eq of Exp*Exp
 | Neg of BExp
 | Con of BExp*BExp
// TT, FF, Eq, Lt, Neg, Con

// semB :: Environment -> BExp -> bool
let rec semB env = function 
  | TT -> true
  | FF -> false
  | Eq (e1,e2) -> sem env e1 = sem env e2
  | Neg b -> not (semB env b)
  | Con (b1,b2) -> semB env b1 &&  semB env b2

let semBtest = semB env (Eq (V "y",C 3))

type Stm = 
 | Assign of (string*Exp)
 | Seq of Stm list
 | IfThenElse of BExp*Stm*Stm
 | While of BExp*Stm

// semS :: Stm -> Environment -> Environment
let rec semS s env = 
  match s with
  | Assign (x,e) ->
     let v = sem env e 
     Map.add x v env
  | Seq [] -> env
  | Seq (c::cs) ->
      let env' = semS c env
      semS (Seq cs) env'
  | IfThenElse (c,s1,s2) ->
      if semB env c 
      then semS s1 env
      else semS s2 env
  | While (c,body) ->
      if semB env c
      then semS (Seq [body;s]) env
      else env


// PRE: given x contains a non-negative value n
// y:=1 ; while !(x=0) do (y:= y*x;x:=x-1)
// POST: y contains factorial of n

let fac = 
  Seq [Assign("y", C 1);
       While(Neg(Eq(V "x", C 0)),
         Seq [Assign("y", Mul(V "x", V "y")) ;
              Assign("x", Sub(V "x", C 1)) 
             ])
      ]
