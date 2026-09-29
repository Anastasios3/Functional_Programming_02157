(* Last week's exercises *)

(* HR 1.4 Define a function $f$ with $f(n)=1+2+\ldots+n$ *)

(* HR 1.6 Define a function $sum$ such that
    $sum(m,n)=m+(m+1)+...+(m+n-1)+(m+n)$ *)

let rec sum (m,n) =
  match n with
  | 0 -> m
  | _ -> m + sum(m+1,n-1)

  //if n=0 then m else  m + sum(m+1,n-1)

(* HR 2.8: Define $\binom{n}{k}$ where $0\leq k\leq n$, 
   according to the definition:
   \begin{eqnarray*}
     \binom{n}{0}=\binom{n}{n}=1 &~~~
     &\binom{n}{k}=\binom{n-1}{k}+\binom{n-1}{k-1}
   \end{eqnarray*}  *)

let rec binom (n,k) =
  match k with
  | 0 -> 1
  | _ when n=k -> 1
  | _ -> binom(n-1,k-1) + binom(n-1,k)



(* Recall also from last lecture: *)

let rec fact n = if n=0 then 1 else n*fact(n-1)  

let binom (n,k) = fact(n) / fact(k) / fact(n-k)

let rec binom (n,k) = if k=0 then 1 else binom(n-1,k-1)*n/k

(* Higher-Order Functions *)

let rec powerC = 
  fun x -> 
    fun n -> 
      match n with
      | 0 -> 1.0
      | _ -> x * powerC x (n-1)

(* Lists *)

let l1=[2;3;6]
let l2=["a"; "ab"; "abc"; ""]
let l3=[sin; cos]
let l4=[(1,true); (3,true)]

let x=List.head l1
let xs=List.tail l1

// Pattern matching over lists

let rec suml list = 
(* such that suml [x1;...;xn] = x1+...+xn *)
   match  list with
   | [] -> 0
   | x::xtail -> x + suml xtail

let rec length l =
  match l with
  | [] -> 0
  | _::xs -> 1 + length xs



// Polymorphic example

let rec remove y xs = 
  match xs with
  | [] -> []
  | (x::tail) -> if x=y then remove y tail 
                 else x:: remove y tail

(* such that remove 2 [1; 2; 0; 2; 7] = [1; 0; 7] *)

// Polymorphic

let rec isPrefix xs ys =  ...
(* isPrefix [1; 2; 3] [1; 2; 3; 8; 9] = true
   isPrefix [1; 2; 3] [1; 2; 8; 3; 9] = false
*)

(* Functional decomposition *)

let rec sort l = 
  match l with
  | [] -> []
  | x::xs -> insert x (sort xs)

(* Easy if we first define a helper function: 
   given an already sorted list l, insert a new element
   x such that the result is a sorted list. *)

let rec insert x l = 
  // assume l is sorted
  match l with
  | [] -> [x]
  | (y::ys) -> if x>y then y :: insert x ys
               else x :: l

(* Runtime? Better idea? *)

let rec sumProd l = ...

(* Infix Operators: 

Define a concatenation operator @ 
such that [x1;...;xn]@[y1;...;ym] = [x1;...;xn;y1;...;ym]

(actually built in)

Use @ to define rev that reverses a list, i.e., 
rev [x1;...;xn] = [xn;...;x1]   (actually also built in)

Can you do it in linear time?

Define a from-to operator <..> such that
   n <..> m = [] if n>m 
   n <..> m = [n;n+1;...;m-1;m]  otherwise
*)