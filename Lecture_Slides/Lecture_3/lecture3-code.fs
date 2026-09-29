(* Exercises from last week *)
// Exercise fibonacci numbers...
let rec fib n = 
  if n<2 then n else
  fib (n-1) + fib (n-2)

let fib n = 
  let rec fib' n f1 f2 = 
    if n=0 then f1 else
    fib' (n-1) f2 (f1+f2)
  fib' n 0 1 
  
// string repetition
let rec pow(s,n) = ...

// number of occurrences of x in xs:
let rec multiplicity x xs = ...

multiplicity 'a' ['b';'a';'n';'a';'n';'a']

(* Polynomes: *)

type Poly = int list

// mulC: int -> Poly -> Poly

let rec mulC c (p:Poly) = 
  match p with
  | [] -> []
  | x::xs -> c*x :: mulC c xs

let test1 = mulC 3 [1;2;3] = [3;6;9]

// mulX: Poly -> Poly

let mulX p = 0 :: p

let test2 = mulX [1;2;3] = [0;1;2;3]

add: Poly -> Poly -> Poly

let rec add p1 p2 = 
  match (p1,p2) with
  | ([],_) -> p2
  | (_,[]) -> p1
  | (x::xs,y::ys) 
     -> x+y  ::  add xs ys
     
let test3 = add [1;2;3] [0;1] = [1;3;3]

// mul: Poly -> Poly -> Poly

let rec mul p1 p2 = 
  match p1 with
  | []     -> []  
  | c::cs  -> 
     add 
       (mulC c p2)
       (mulX (mul cs p2))

let test4 = mul [2;3;0;1] [1;2;3]= [2;7;12;10;2;3]


type Poly=int list;;

let rec mulC c list = ...
let rec mulX list = ...
let rec add l1 l2 = ...
let rec mul p1 p2 = ...

(* Mergesort 

split: int->’a list->(’a list,’a list)

let test2 = split 2 [1;2;3;4;5] = ([1;2],[3;4;5])

let test = mergesort [4;23;0;12;3;5] = [0; 3; 4; 5; 12; 23]
*)

let rec split n l = // n>=0
  if n=0 then ([],l) else
  match l with
  | [] -> failwith "Splitting empty list"
  | (x::xs)  -> let (l1,l2) = split (n-1) xs   
                (x::l1,l2)

let rec merge l1 l2 = 
  match (l1,l2) with
  | ([],_) -> l2
  | (_,[]) -> l1
  | (x::xs,y::ys) -> 
     if x<=y then x :: merge xs (y::ys)
             else y :: merge (x::xs) ys

let rec mergesort l =
  let n = List.length l
  if n<2 then l else
  let (l1,l2) = split (n/2) l
  let ls1 = mergesort l1
  let ls2 = mergesort l2
  merge ls1 ls2
  
             



/* function composition  (f << g)(x) = f(g(x))
Thus if g: a -> b   f : b -> c, then   f << g : a-> c  */

let (<<) f g = fun x -> f (g x) 

let f y = y+3
let g x = x*x

let h =  f << g 

// Function composition (<<) is a builtin function, 
// but it is easy to define:

let (<<) f g x = ...    //  f << g  = (<<) f g

// could also be written as:
let (<<) f g = ...

// exponentiation (^^) is also built in

let rec (^^) x n = if n=0 then 1.0 else x* (x ^^ (n-1)) 

(* Infix Operators: 

Define a concatenation operator @ 
such that [x1;...;xn]@[y1;...;ym] = [x1;...;xn;y1;...;ym]

Also builtin
*) 

let rec (@) l1 l2 = 
  match l1 with
  | [] -> l2
  | (x::xs) -> x :: (xs @ l2)




(* Use @ to define rev that reverses a list, i.e., 
rev [x1;...;xn] = [xn;...;x1]   *)

// Quadratic - can you do it in linear time?

// Idea: rev [1;2;3] [] -> rev [2;3] [1] -> rev [3] [2;1] -> rev [] [3;2;1] -> [3;2;1]

(* Left as an exercise: 
Define a from-to operator <..> such that
   n <..> m = [] if n>m 
   n <..> m = [n;n+1;...;m-1;m]  otherwise

  ex: 1 <..> 3 = [1;2;3]
*)
