(* Exercises from last week 
HR 4.3
evenN n : list of first n non-negative even numbers

HR 4.8 
split [x_0;...;x_n-1] = ([x_0;x_2;...],[x_1;x_3;...])

HR 4.9
zip ([x_0;...;x_n-1],[y_0;...;y_n-1]) = [(x_0,y_0);...;(x_n-1,y_n-1)]

HR 4.12
sum(p,xs) = sum of [ x in xs | p(x) ]
test: sum all positive numbers in [1;-1;2;-2;3;-3];

*)

let rec p q = function
  | [] -> []
  | x::xs -> let ys = p q xs
             if q x then x::ys else ys@[x]


(* Algebraic Data Types *)

type Shape = | Circle of float 
             | Square of float 
             | Triangle of float*float*float
             
let exampleshapelist = [Circle 1.0; Square 3.0; Triangle (3.0,4.0,5.0)]

let area = function
  | Circle r -> System.Math.PI * r * r
  | Square a -> a * a
  | Triangle(a,b,c) ->
  let s = (a + b + c)/2.0
  sqrt(s*(s-a)*(s-b)*(s-c)) 

let rec findPosH c x = function
  | [] -> None
  | y::ys -> if x=y then Some c
             else findPosH (c+1) x ys

let findPos x ys = findPosH 0 x ys



(* Room is either an auditorium of a given #seats or a databar with a given #seats and #computers *)

type Room = Auditorium of int
          | Databar of int*int

let seatCapacity room = 
  match room with
  | Auditorium seats -> seats
  | Databar (seats,computers) -> seats

let computerCapacity room = 
  match room with
  | Auditorium _ -> 0
  | Databar (_,computers) -> computers

(* Lists as Algebraic Data Types *)

type 'a mylist = | Empty 
                 | Cons of ('a*'a mylist)
               
// define sum : int mylist -> int ...

let rec sum l = 
  match l with
  | Empty -> 0
  | Cons (x,xs) -> x+ sum xs

(* Higher-Order Functions
   We did not do them during the lecture, 
   but here added for completeness
 *)

let rev list = 
  List.fold (fun ac x -> x::ac) [] list

let contains x ys = 
  List.exists (fun y -> x=y) ys

let disjoint xs ys = 
  List.forall (fun x -> not (contains x ys)) xs

let inter xs ys = 
  List.filter (fun x -> contains x ys) xs

let rec tryFind p = function
  | x::xs when p x -> Some x
  | _::xs -> tryFind p xs
  | _ -> None;;
// Without recursion:
let tryFind p l =
  let f ac x = if p x then Some x else ac
  List.fold f None l

let insert x ys = if List.contains x ys then ys
                  else x::ys
