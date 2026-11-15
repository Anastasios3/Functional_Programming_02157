// Mini-Compiler: solution

type Exp = V of string
         | C of int
         | Add of Exp*Exp
         | Sub of Exp*Exp
         | Minus of Exp
         | Abs of Exp

type Environment = Map<string,int>

// sem : Environment -> Exp -> int
let rec sem env e = 
  match e with
  | V x -> Map.find x env // will cause an error if variable not found
  | C i -> i
  | Add(n,m) -> sem env n + sem env m
  | Sub(n,m) -> sem env n - sem env m
  | Minus n -> - sem env n
  | Abs n -> abs (sem env n)

let env = Map.ofList [("x",3);("y",-3)]
let example = Add(Abs(Minus(C 7)), Sub(V "x", Minus(Add(C 2, V "y"))))
let test = sem env example

// Virtual Machine
type Instruction = | ADD | SUB | SIGN | ABS | PUSH of int
type Stack = int list

// intpInstr: Instruction -> Stack -> Stack
let intpInstr i st = 
  match (i,st) with
  | (ADD,(n::m::rest)) -> m+n ::rest
  | (SUB,(n::m::rest)) -> m-n ::rest
  | (SIGN,(n::rest))   -> -n :: rest
  | (ABS,(n::rest))    -> (abs n)::rest
  | (PUSH n,_)         -> n::st
