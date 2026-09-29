(* Lecture1 code *)

(* Part 3: Introduction to F# *)

// 1. Simple expressions and declarations

// Expressions
2*3+4

// Definitions
let price = 25 * 5
let newPrice = 2*price
newPrice > 500

// Function Definitions (non-recursive)
let circleArea r = System.Math.PI * r * r
circleArea 1.0 (* this is a comment *)
circleArea(3.2)

// 2. Recursive function definitions

// Function Definitions (recursive)
// 0! = 1
// n! = n * (n-1)!
let rec fact n = 
  if n=0 then 1 
  else n * fact (n-1)

// Syntax unlocked so far

// 3. Pattern matching

let rec power(x,n) =
  if (n=0) then 1.0
  else x * power(x,n-1)

let rec powersq(x,n) =
  if (n=0) then 1.0
  else if n%2=0 then let r=powersq(x,n/2)
                     in r*r
       else x* powersq(x,n-1)

// Function Definition with pattern matching
let rec pow(x,n) = 
  match (x,n) with
  | (_,0) -> 1.0
  | (x,n) -> x*pow(x,n-1)

// Pattern matching example

let test=
  match (3+5, 3<5) with
  | (0, _) -> 0
  | (n,false) -> -n
  | (n,_) -> 2*n

// 4. Types

// 5. Higher-Order or "curried" or "schönfinkeled" version of power:

let rec power x n = ...

let pow2 = power 2.0

// 6. Using anonymous functions:

function
| 2 -> 28 // February
| 4 -> 30 // April
| 6 -> 30 // June
| 9 -> 30 // September
| 11 -> 30 // November
| _ -> 31;; // All other months

let rec power x = ...

(* Part 4 Lists *)

let l1=[2;3;6]
let l2=["a"; "ab"; "abc"; ""]
let l3=[sin; cos]
let l4=[(1,true); (3,true)]

let x=List.head l1
let xs=List.tail l1

// Pattern matching over lists

let rec suml list = ... 
(* such that suml [x1;...;xn] = x1+...+xn *)

// Another example

let rec remove y xs = ...
(* such that remove 2 [1; 2; 0; 2; 7] = [1; 0; 7] *)

// Polymorphic

let rec isPrefix xs ys =  ...
(* isPrefix [1; 2; 3] [1; 2; 3; 8; 9] = true
   isPrefix [1; 2; 3] [1; 2; 8; 3; 9] = false
*)