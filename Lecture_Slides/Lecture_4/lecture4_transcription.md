[Page 1]02157 Functional Programming
Week 4:
Algebraic Data Types & Higher-order list functions
02157 Functional Programming, Week 4
Sebastian Mödersheim
Based on slides by Michael Reichhardt Hansen
September 25, 2026
1 of 38

[Page 2]1 Algebraic Data Types
 Higher-order list functions
Outline
02157 Functional Programming, Week 4
2 of 38

[Page 3]-
Part I: Disjoint Union  An Example
A shape is either a circle, a square, or a triangle
the union of three disjoint sets
02157 Functional Programming, Week 4
3 of 38

[Page 4]-
Part I: Disjoint Union – An Example
A shape is either a circle, a square, or a triangle
• the union of three disjoint sets
type Shape =
 Circle of float
$(*1*)$
| Square of float
$(*2*)$
| Triangle of float*float*float;;
$(*3*)$
02157 Functional Programming, Week 4
3 of 38

[Page 5]-
Part I: Disjoint Union – An Example
A shape is either a circle, a square, or a triangle
• the union of three disjoint sets
type Shape =
 Circle of float
(* 1 *)
| Square of float
(* 2 *)
| Triangle of float*float*float;;
(* 3 *)
This declaration provides three rules for generating shapes:
ifr: float, then Circle r: Shape
• if s: float, then Squares: Shape
• if (a, b, c): float*float*float,
then Triangle(a, b, c): Shape
02157 Functional Programming, Week 4
(*1*)
(* 2 *)
$(*3*)$
3 of 38

[Page 6]-
Part I: Disjoint Union – An Example
A shape is either a circle, a square, or a triangle
• the union of three disjoint sets
type Shape =
 Circle of float
(* 1 *)
| Square of float
(* 2 *)
| Triangle of float*float*float;;
(* 3 *)
This declaration provides three rules for generating shapes:
ifr: float, then Circle r: Shape
• if s: float, then Squares: Shape
• if (a, b, c): float*float*float,
then Triangle(a, b, c): Shape
A type like Shape is also called an algebraic data type
02157 Functional Programming, Week 4
(*1*)
$(*2*)$
$(*3*)$
3 of 38

[Page 7]Part I: Disjoint Sets - An Example (II)
The tags Circle, Square and Triangle are called constructors:
Circle
: float → Shape
Square
: float → Shape
Triangle :
float * float  float
Shape
Constructors are functions.
They construct in this case value of Shape and they are the only way to construct
values of type Shape.
Circle 2.0;;
> val it: Shape = Circle 2.0
Triangle (1.0, 2.0, 3.0);;;
> val it : Shape = Triangle (1.0, 2.0, 3.0)
Square 4.0;;
> val it: Shape = Square 4.0
02157 Functional Programming, Week 4
4 of 38

[Page 8]Algebraic Data Types are Inductive Defintions
The declaration
type Shape
=
 Circle of float
| Square of float
| Triangle of float*float*float;;
$(*1*)$
$(*2*)$
$(*3*)$
is equivalent to the form of (inductive) definitions we have used for the syntax:
Shape
A Shape is any of the following:
 Circle (r) where r is a float.
• Square(a) where a is a float.
• Triangle(a, b, c) where a, b, c are floats.
and nothing else is a Shape.
This means two things:
• We can define any kind of hierarchical data structures with them (like lists and
trees, syntax).
• The constructors can be used for pattern matching because they are the
disjoint cases of the data type they construct.
02157 Functional Programming, Week 4
5 of 38

[Page 9]Constructors in Patterns
A Shape can only be constructed by one of the constructors. Thus it always has the
form
Circle r
• Square a
• Triangle (a,b,c)
A shape-area function is declared
let area =
function
| Circle r
| Square a
System.Math.PI $PI*r*r$
-> a * a
| Triangle(a,b,c) ->
let $s=(a+b+c)/2.0$
sqrt $(s*(s-a)*(s-b)*(s-c))$;;
> val area : Shape -> float
following the structure of shapes.
using Heron's formula
02157 Functional Programming, Week 4
6 of 38

[Page 10]Constructors in Patterns
A Shape can only be constructed by one of the constructors. Thus it always has the
form
Circle r
• Square a
• Triangle (a,b,c)
A shape-area function is declared
let area =
function
| Circle r
| Square a
System.Math.PI $PI*r*r$
-> a * a
| Triangle(a,b,c) ->
let $s=(a+b+c)/2.0$
sqrt $t(s*(s-a)*(s-b)*(s-c))$;;
> val area : Shape -> float
following the structure of shapes.
a constructor only matches itself
using Heron's formula
02157 Functional Programming, Week 4
6 of 38

[Page 11]Constructors in Patterns
A Shape can only be constructed by one of the constructors. Thus it always has the
form
Circle r
• Square a
• Triangle (a,b,c)
A shape-area function is declared
let area =
function
| Circle r
| Square a
System.Math.PI $PI*r*r$
-> a * a
| Triangle(a,b,c) ->
let $s=(a+b+c)/2.0$
sqrt $t(s*(s-a)*(s-b)*(s-c))$;;
> val area : Shape -> float
following the structure of shapes.
a constructor only matches itself
02157 Functional Programming, Week 4
area (Circle 1.2)
using Heron's formula
(System.Math.PI $PI*r*r$, $[r\mapsto1.2])$
6 of 38

[Page 12]Enumeration types - the months
Months are naturally defined using tagged values::
type Month =
| January | February | March | April
| May | June | July | August | September
| October | November | December;;
02157 Functional Programming, Week 4
7 of 38

[Page 13]Enumeration types  the months
Months are naturally defined using tagged values::
| January | February | March | April
type Month =
| May | June | July | August | September
| October | November | December;;
The days-in-a-month function is declared by
let daysOfMonth =
function
| February
28
| April | June | September | November
-> 30
-> 31;;
val daysOfMonth: Month -> int
02157 Functional Programming, Week 4
7 of 38

[Page 14]Enumeration types  the months
Months are naturally defined using tagged values::
| January | February | March | April
type Month =
| May | June | July | August | September
| October | November | December;;
The days-in-a-month function is declared by
| let daysOfMonth =   |  |  |
| function  \| February   |  | 28   |
| \| April \| June \| September \| November   | >   | 30   |
| val daysOfMonth: Month  int   |  | 31;;   |
Observe: Constructors need not have arguments
02157 Functional Programming, Week 4
7 of 38

[Page 15]The option type
type 'a option = None | Some of 'a
Distinguishes the cases "nothing" and "something".
predefined
02157 Functional Programming, Week 4
8 of 38

[Page 16]The option type
type 'a option = None | Some of 'a
Distinguishes the cases "nothing" and "something".
The constructor Some and None are polymorphic:
Some false;;
val it: bool option = Some false
(int * string) option = Some (1, "a")
Some (1,
"a");;
val it:
None;;
val it :
'a option
= None
02157 Functional Programming, Week 4
predefined
8 of 38

[Page 17]The option type
type 'a option = None | Some of 'a
Distinguishes the cases "nothing" and "something".
The constructor Some and None are polymorphic:
Some false;;
val it: bool option = Some false
Some (1,
"a");;
val it:
(int * string) option = Some (1, "a")
None;;
val it :
'a option
= None
predefined
Observe: type variables are allowed in declarations of algebraic types
02157 Functional Programming, Week 4
8 of 38

[Page 18]Example: Find first position of element in a list
findPos x 1:
• give None if x does not occur in 1
 give Some p if p is the first position where x occurs in 1
02157 Functional Programming, Week 4
9 of 38

[Page 19]Exercise
A (teaching) room at DTU is either an auditorium or a databar:
an auditorium is characterized by a location and a number of seats.
 a databar is characterized by a location, a number of computers and a number
of seats.
Declare a type Room.
02157 Functional Programming, Week 4
10 of 38

[Page 20]Exercise
A (teaching) room at DTU is either an auditorium or a databar:
an auditorium is characterized by a location and a number of seats.
 a databar is characterized by a location, a number of computers and a number
of seats.
Declare a type Room.
Declare a function:
02157 Functional Programming, Week 4
seatCapacity: Room → int
10 of 38

[Page 21]Exercise
A (teaching) room at DTU is either an auditorium or a databar:
an auditorium is characterized by a location and a number of seats.
 a databar is characterized by a location, a number of computers and a number
of seats.
Declare a type Room.
Declare a function:
seatCapacity: Room → int
Declare a function
computerCapacity : Room → int option
02157 Functional Programming, Week 4
10 of 38

[Page 22]Lists are an Algebraic Data Type
We can actually define lists using an algebraic data type:
type 'a mylist =
| Empty
| Cons of ('a*'a mylist)
To avoid conflicts with the built-in concept of list there are different names:
• Empty for
• Cons for ::
• mylist for list
• With this data type one would write for instance
Cons (3, Cons (4, Cons (5, Empty))) for the list [3;4;5].
• We can do all the pattern matching as usual.
02157 Functional Programming, Week 4
11 of 38

[Page 23]1 Algebraic Data Types
 Higher-order list functions
Outline
02157 Functional Programming, Week 4
12 of 38

[Page 24]Motivation
Higher-order functions are
 everywhere
$\Sigma_{i=a}^{b}f(i),\frac{df}{dx},\{x\in A|P(x)\},...$
02157 Functional Programming, Week 4
13 of 38

[Page 25]Motivation
Higher-order functions are
 everywhere
$\Sigma_{i=a}^{b}f(i),\frac{df}{dx},\{x\in A|P(x)\},...$
• powerful
Parameterized modules, succinct code...
02157 Functional Programming, Week 4
13 of 38

[Page 26]Motivation
Higher-order functions are
 everywhere
$\Sigma_{i=a}^{b}f(i),\frac{df}{dx},\{x\in A|P(x)\},...$
• powerful
Parameterized modules, succinct code...
HIGHER-ORDER FUNCTIONS ARE USEFUL
02157 Functional Programming, Week 4
13 of 38

[Page 27]Recursion over a List
Many recursive declarations work recursively along a list:
let rec $f=$ function
->
...
| x::xs ->
f(xs) ...
Many of these functions have a simple common shape:
Applying a function on each list element
let rec squarelist = function
| [] -> []
| x::xs -> x*x :: squarelist xs
Collecting list elements that have a certain property
let rec evens = function
|
[] -> []
| x::xs -> if $x\%2=0$ then x :: evens xs else evens xs
Combining all list elements with a function
let rec sum = function
| $[]->0$
|
(x::xs)
x + sum xs
02157 Functional Programming, Week 4
14 of 38

[Page 28]Recursion over a List
Many recursive declarations work recursively along a list:
let rec $f=$ function
->
...
| x::xs ->
f(xs) ...
Many of these functions have a simple common shape:
Applying a function on each list element
let rec squarelist = function
| [] -> []
| x::xs -> $x*x$ :: squarelist xs
Collecting list elements that have a certain property
let rec evens = function
|
[] -> []
| x::xs -> if $x\%2=0$ then x :: evens xs else evens xs
Combining all list elements with a function
let rec sum = function
| $[]->0$
|
(x::xs) -> x + sum xs
We can write that more succinct using higher-order functions
02157 Functional Programming, Week 4
14 of 38

[Page 29]Recursion over a List
Many recursive declarations work recursively along a list:
let rec $f=$ function
|
[]
 
x::xs
...
f(xs)
...
Applying a function on each list element
let squarelist list = List.map $(fun~x->x*x)$ list
Collecting list elements that have a certain property
let evens list = List.filter $(\begin{matrix}f~un~x->x\%2=0\end{matrix})$ list
Combining all list elements with a function
let sum list = List.fold (+) 0 list
This is the more succinct version using the higher-order functions
List.map List. filter List.fold
02157 Functional Programming, Week 4
15 of 38

[Page 30]Recursion over a List
Many recursive declarations work recursively along a list:
let rec $f=$ function
| []
 $\begin{matrix}x::xs&->&...&f(xs)...\end{matrix}$
Applying a function on each list element
let squarelist list = List.map $(\begin{matrix}fun~x->x*x\end{matrix})$ list
Collecting list elements that have a certain property
let evens list = List.filter $(\begin{matrix}f~un~x->x\%2=0\end{matrix})$ list
Combining all list elements with a function
let sum list = List.fold (+) 0 list
This is the more succinct version using the higher-order functions
List.map List. filter List.fold
Avoid (almost) identical code fragments by
parameterizing functions with functions
02157 Functional Programming, Week 4
15 of 38

[Page 31]A simple declaration of a list function
A typical declaration following the structure of lists:
let rec posList = function
| $x::xs\rightarrow(x>0)$:: posList xs;;
val posList: int list -> bool list
posList [4; -5; 6];;
val it: bool list = [true; false; true]
02157 Functional Programming, Week 4
16 of 38

[Page 32]A simple declaration of a list function
A typical declaration following the structure of lists:
let rec posList = function
val posList: int
| x::xs -> (x > 0):: posList xs;;
list -> bool list
posList [4; -5; 6];;
val it: bool list = [true; false; true]
Applies the function fun $x->x>0$ to each element in a list
02157 Functional Programming, Week 4
16 of 38

[Page 33]Another declaration with the same structure
let rec addElems = function
| []
| $(x,y)::zs\rightarrow(x+y)$::addElems zs;;
val addElems: (int * int) list -> int list
addElems [(1,2);(3,4)];;
val it: int list = [3; 7]
02157 Functional Programming, Week 4
17 of 38

[Page 34]Another declaration with the same structure
let rec addElems = function
|
[]
|
(x,y)::zs -> (x+y)::addElems zs;;
val addElems: $(int*int)$ list -> int list
addElems [(1,2);(3,4)];;
val it: int list = [3; 7]
Applies the addition function + to each pair of integers in a list
02157 Functional Programming, Week 4
17 of 38

[Page 35]The function: map
Applies a function to each element in a list
$map~f[v_{1};v_{2};...;v_{n}]=[f(v_{1});f(v_{2});...;f(v_{n})]$
Declaration
let rec map $f=$ function
| [] -> []
| x::xs -> f x :: map f xs;;
$val~map:(^{\prime}a\rightarrow^{\prime}b)\rightarrow^{\prime}a~list\rightarrow^{\prime}b~list$
02157 Functional Programming, Week 4
Library function
18 of 38

[Page 36]The function: map
Applies a function to each element in a list
$map~f[v_{1};v_{2};...;v_{n}]=[f(v_{1});f(v_{2});...;f(v_{n})]$
Declaration
let rec map $f=$ function
|
[]
-> []
|
x::xs
-> f x :: map f xs;;
val map : ('a ->
'b)
->
'a list -> 'b list
Succinct declarations can be achieved using map, e.g.
=
let posList map (fun x -> x > 0);;
val posList: int list -> bool list
let addElems = map (fun (x,y) -> x+y);;
val addElems: $(int*int)$ list -> int list
02157 Functional Programming, Week 4
Library function
18 of 38

[Page 37]Declare a function
Exercise
$\mathfrak{muIC}[x_{1},...,x_{n}]=[c*x_{1},...,c*x_{n}]$
Remember
map $f[v_{1};v_{2};...;v_{n}]=[f(v_{1});f(v_{2});...;f(v_{n})]$
where
map: ('a -> 'b) -> 'a list -> 'b list
02157 Functional Programming, Week 4
19 of 38

[Page 38]Higher-order list functions: exists
Predicate: For some x in $xs:p(x)$.
02157 Functional Programming, Week 4
20 of 38

[Page 39]Higher-order list functions: exists
Predicate: For some x in xs : p(x).
exists p xs =
{
true
false
if p(x) = true for some x in xs
otherwise
02157 Functional Programming, Week 4
20 of 38

[Page 40]Higher-order list functions: exists
Predicate: For some x in xs : p(x).
{
true
false
if $p(x)=$ true for some x in xs
otherwise
exists p xs =
Declaration
let rec exists $p=$
function
| []
-> false
| x::xs -> px || exists p xs;;
val exists : $(^{\prime}a\rightarrow bool)\rightarrow^{\prime}a~list\rightarrow bool$
02157 Functional Programming, Week 4
Library function
20 of 38

[Page 41]Higher-order list functions: exists
Predicate: For some x in xs : p(x).
{
true
false
if $p(x)=$ true for some x in xs
otherwise
exists p xs =
Declaration
let rec exists $p=$
function
| []
-> false
| x::xs -> px || exists p xs;;
val exists : $(^{\prime}a\rightarrow bool)\rightarrow^{\prime}a~list\rightarrow bool$
Example
exists $(\begin{matrix}f~un~x->x>=2\end{matrix})$ [1; 3; 1; 4];;
val it: bool = true
02157 Functional Programming, Week 4
Library function
20 of 38

[Page 42]Exercise
Declare contains function using exists.
let contains x ys = exists ????? ;;
val contains: 'a -> 'a list -> bool when 'a: equality
Remember
where
exists p xs =
exists: ('a -> bool)
contains is a Library function
{
true if $p(x)=$ true for some x in xs
false
otherwise
'a list bool
02157 Functional Programming, Week 4
21 of 38

[Page 43]Higher-order list functions: forall
Predicate: For every x in xs : p(x).
02157 Functional Programming, Week 4
22 of 38

[Page 44]Higher-order list functions: forall
Predicate: For every x in xs : p(x).
forall p xs =
02157 Functional Programming, Week 4
}
true
false
if p(x) = true, for all elements x in xs
otherwise
22 of 38

[Page 45]Higher-order list functions: forall
Predicate: For every x in xs : p(x).
forall p xs =
{
true
false
if $p(x)=$ true, for all elements x in xs
otherwise
Declaration
let rec forall $p=$
function
| []
-> true
| x::xs -> p x && forall p xs;;
val forall : $(^{\prime}a\rightarrow bool)\rightarrow^{\prime}a~list\rightarrow bool$
02157 Functional Programming, Week 4
Library function
22 of 38

[Page 46]Higher-order list functions: forall
Predicate: For every x in xs : p(x).
forall p xs =
true
false
if $p(x)=$ true, for all elements x in xs
otherwise
Declaration
let rec forall $p=$
function
| []
-> true
| x::xs -> p x && forall p xs;;
val forall : $^{\prime}a\rightarrow bool)\rightarrow^{\prime}a~list\rightarrow bool$
Example
forall $(\begin{matrix}f~un~x->x>=2\end{matrix})$ [1; 3; 1; 4];;
val it: bool = false
02157 Functional Programming, Week 4
Library function
22 of 38

[Page 47]Declare a function
Exercises
disjoint xs ys
which is true when there are no common elements in the lists xs and ys, and false
otherwise.
Remember
$foral1~\rho~xs=\{\begin{matrix}true&if~p(x)=true,for~all~ements\times in~xs\\ false&otherwise\end{matrix}$
where
forall : ( a -> bool) -> 'a list -> bool
02157 Functional Programming, Week 4
23 of 38

[Page 48]Higher-order list functions: filter
Set comprehension: $\{x\in xs:p(x)\}$
02157 Functional Programming, Week 4
24 of 38

[Page 49]Higher-order list functions: filter
Set comprehension: $\{x\in xs:p(x)\}$
filter p xs is the list of those elements x of xs where $p(x)=$ true.
02157 Functional Programming, Week 4
24 of 38

[Page 50]Higher-order list functions: filter
Set comprehension: $\{x\in xs:p(x)\}$
filter p xs is the list of those elements x of xs where $p(x)=$ true.
Declaration
let rec filter $p=$
function
|
[]
|
x::xs
if px then x :: filter p xs
else filter p xs;;
val filter :
('a -> bool) -> 'a list -> 'a list
02157 Functional Programming, Week 4
Library function
24 of 38

[Page 51]Higher-order list functions: filter
Set comprehension: $\{x\in xs:p(x)\}$
filter $p\times s$ is the list of those elements x of xs where $p(x)=$ true.
Declaration
let rec filter
$p=$
function
|
[]
|
x::xs
if px then x :: filter p xs
Library function
else filter p xs;;
val filter : ('a -> bool) -> 'a list -> 'a list
Example
filter System.Char.IsLetter ['1'; 'p'; 'F'; '-'];;
val it: char list $=\lceil^{\prime}p^{\prime}$; 'F']
where System.Char. IsLetter c is true iff $c\in\{^{\prime}A^{\prime},...,^{\prime}Z^{\prime}\}\cup\{^{\prime}a^{\prime},...,^{\prime}z^{\prime}\}$
02157 Functional Programming, Week 4
24 of 38

[Page 52]Declare a function
Exercise
inter xs ys
which contains the common elements of the lists xs and ys i.e. their intersection.
Order and repetition of elements are of no concern
Remember:
filter p xs is the list of those elements x of xs where $p(x)=$ true. where
filter: ('a -> bool)
'a list -> 'a list
02157 Functional Programming, Week 4
25 of 38

[Page 53]Higher-order list functions: tryFind
{
Some x
None
for an element x of xs with p(x) = true
if no such element exists
tryFind $p~xs=$
02157 Functional Programming, Week 4
26 of 38

[Page 54]Higher-order list functions: tryFind
tryFind $p~xs=$
{
Some x
None
for an element x of xs with $p(x)=$ true
if no such element exists
let rec tryFind
function
| x::xs when
:: XS
$p=$
$p~x->$
Some x
tryFind p xs
-> None;;
val tryFind : ('a -> bool) -> 'a list -> 'a option
02157 Functional Programming, Week 4
26 of 38

[Page 55]Higher-order list functions: tryFind
tryFind $p~xs=$
{
Some x
None
for an element x of xs with $p(x)=$ true
if no such element exists
let rec tryFind
function
| x::xs when
:: XS
$p=$
$p~x->$
Some x
tryFind p xs
-> None;;
val tryFind : ('a -> bool) -> 'a list -> 'a option
tryFind $(fun~x->x>3)$ [1;5;-2;8];;
val it: int option = Some 5
02157 Functional Programming, Week 4
26 of 38

[Page 56]Folding a function over a list (1)
Example: sum of absolute values:
let rec absSum = function
0
| x::xs -> abs x + absSum xs;;
val absSum: int list -> int
absSum [-2; 2; -1; 1; 0];;
val it: int $=6$
02157 Functional Programming, Week 4
27 of 38

[Page 57]Folding a function over a list (II)
let rec absSum = function
0
| x::xs -> abs x + absSum xs;;
Let $f\times a$ abbreviate abs
$x+a$
in the evaluation:
02157 Functional Programming, Week 4
absSum $[x_{0};x_{1};...;x_{n-1}]$
abs  + (absSum [X1;...; Xn-1])
$=f~x_{0}(absSum[x_{1};...;x_{n-1}])$
$f~x_{0}(f~x_{1}(absSum[x_{2};...;x_{n-1}]))$
←~
~
f $x_{0}(f~x_{1}(\cdot\cdot\cdot(f~x_{n-1}0)\cdot\cdot\cdot))$
28 of 38

[Page 58]Folding a function over a list (II)
let rec absSum = function
0
| x::xs -> abs x + absSum xs;;
Let $f\times a$ abbreviate abs
$x+a$
in the evaluation:
absSum $[x_{0};x_{1};...;x_{n-1}]$
abs  + (absSum [X1;...; Xn-1])
$=f~x_{0}(absSum[x_{1};...;x_{n-1}])$
$\leftrightarrow f~x_{0}(f~x_{1}(absSum[x_{2};...;x_{n-1}]))$
  
$f~x_{0}(f~x_{1}(\cdot\cdot\cdot(f~x_{n-1}0)\cdot\cdot\cdot))$
This repeated application of f is also called a folding of f.
02157 Functional Programming, Week 4
28 of 38

[Page 59]Folding a function over a list (II)
let rec absSum = function
0
| x::xs -> abs x + absSum xs;;
Let $f\times a$ abbreviate abs
$x+a$
in the evaluation:
absSum $[x_{0};x_{1};...;x_{n-1}]$
abs x0 + (absSum [X1;...; Xn-1])
= $=f~x_{0}(absSum[x_{1};...;x_{n-1}])$
$\mapsto f~x_{0}(f~x_{1}(absSum[x_{2};...;x_{n-1}]))$
← 
$f~x_{0}(f~x_{1}(\cdot\cdot\cdot(f~x_{n-1}0)\cdot\cdot\cdot))$
This repeated application of f is also called a folding of f.
Many functions follow such recursion and evaluation schemes
02157 Functional Programming, Week 4
28 of 38

[Page 60]Higher-order list functions: foldBack (1)
Suppose that is an infix function. Then
foldBack (
[ao; a1;
; an-2; an-1] eb
$=a_{0}\otimes(a_{1}\otimes(...(a_{n-2}\otimes(a_{n-1}\otimes e_{b}))...))$
02157 Functional Programming, Week 4
29 of 38

[Page 61]Higher-order list functions: foldBack (1)
Suppose that is an infix function. Then
foldBack() [ao; a1;
; an-2; an-1] eb
$=a_{0}\otimes(a_{1}\otimes(...(a_{n-2}\otimes(a_{n-1}\otimes e_{b}))...))$
List.foldBack (+)
List.foldBack (-)
 1;
(1;
2; 3] $\begin{matrix}0&=&1+(2+(3+0)\end{matrix}=6$
2; 3] $\begin{matrix}0&=&1-(2-(3-0)\end{matrix})=&2\end{matrix}$
02157 Functional Programming, Week 4
29 of 38

[Page 62]Declaration of foldBack
let rec foldBack f xlst e =
match xlst with
| x::xs ->
| []
f x (foldBack f xs e)
-> e;;
val foldBack : $(^{\prime}a\rightarrow^{\prime}b\rightarrow^{\prime}b)\rightarrow^{\prime}a~list\rightarrow^{\prime}b\rightarrow^{\prime}b$
02157 Functional Programming, Week 4
30 of 38

[Page 63]Declaration of foldBack
let rec foldBack f xlst e =
match xlst with
| x::xs ->
| []
f x (foldBack f xs e)
-> e;;
val foldBack: $(^{\prime}a\rightarrow^{\prime}b\rightarrow^{\prime}b)\rightarrow^{\prime}a~list->^{\prime}b\rightarrow^{\prime}b$
let absSum xs = foldBack (fun x a
abs x + a) xs 0;;
let length xs = foldBack (fun n
n+1) xs 0;;
let map f xs = foldBack (fun x rs
fx :: rs) xs
;;
02157 Functional Programming, Week 4
30 of 38

[Page 64]Exercise
Let an insertion function be declared by
let insert x ys = if List.contains x ys then ys
else x::ys;;
Declare a function distinct xs, that returns a list having same elements as xs but
without duplicated element.
Remember:
where
foldBack $(\oplus)[x_{1};x_{2};...;x_{n}]b\hookrightarrow x_{1}\oplus(x_{2}\oplus\cdot\cdot\cdot\oplus(x_{n}\oplus b)\cdot\cdot\cdot)$
foldBack: ('a -> 'state ->
-> 'a list ->
'state)
'state -> 'state
02157 Functional Programming, Week 4
31 of 38

[Page 65]Higher-order list functions: fold (1)
Suppose that is an infix function.
Then the fold function is defined by:
fold ( ) $e_{a}$ [bo; b1; ; bn-2; bn-1]
$=((...((e_{a}\oplus b_{0})\oplus b_{1})...)\oplus b_{n-2})\oplus b_{n-1}$
i.e. it applies from left to right.
02157 Functional Programming, Week 4
32 of 38

[Page 66]Higher-order list functions: fold (1)
Suppose that is an infix function.
Then the fold function is defined by:
fold ( ) $e_{a}$ [bo; b₁; ; bn-2; bn-1]
$=((...((e_{a}\oplus b_{0})\oplus b_{1})...)\oplus b_{n-2})\oplus b_{n-1}$
i.e. it applies from left to right.
Examples:
List.fold (-) 0 [1; 2; 3]
=
((0-1) -2) - 3
=
-6
02157 Functional Programming, Week 4
32 of 38

[Page 67]Higher-order list functions: fold (1)
Suppose that is an infix function.
Then the fold function is defined by:
fold ( ) $e_{a}$ [bo; $b_{1}$; ; bn-2; bn-1]
$=((...((e_{a}\oplus b_{0})\oplus b_{1})...)\oplus b_{n-2})\oplus b_{n-1}$
i.e. it applies from left to right.
Examples:
List.fold (-)
List.foldBack (-)
02157 Functional Programming, Week 4
0
 1;
=
((0-1) -2) - 3
=
-6
[1; 2; 3]
2; 3] $\begin{matrix}0&=&1-(2-(3-0))&=&2\end{matrix}$
32 of 38

[Page 68]Higher-order list functions: fold (2)
let rec fold f e =
function
| x::xs -> fold f (fe x) xs
| []
-> e;;
val fold: $(^{\prime}a\rightarrow^{\prime}b\rightarrow^{\prime}a)\rightarrow^{\prime}a\rightarrow^{\prime}b~list\rightarrow^{\prime}a$
02157 Functional Programming, Week 4
33 of 38

[Page 69]Higher-order list functions: fold (2)
let rec fold f e =
function
| x::xs -> fold f (fe x) xs
| []
-
> e;;
$\cup al~fold:(^{\prime}a\rightarrow^{\prime}b\rightarrow^{\prime}a)\rightarrow^{\prime}a\rightarrow^{\prime}b~list\rightarrow^{\prime}a$
Using cons in connection with fold gives the reverse function:
let rev XS = fold (fun rs x
x::rs)
xs;;
This function has a linear execution time:
02157 Functional Programming, Week 4
33 of 38

[Page 70]Higher-order list functions: fold (2)
let rec fold $f~e=$
function
| x::xs -> fold f (fe x) xs
| []
-> e;;
val fold: $(^{\prime}a\rightarrow^{\prime}b\rightarrow^{\prime}a)\rightarrow^{\prime}a\rightarrow^{\prime}b~list\rightarrow^{\prime}a$
Using cons in connection with fold gives the reverse
function:
let rev $xs=$ fold (fun rs x x::rs)
xs;;
This function has a linear execution time:
←~
←~
←~
~
←~
rev [1;2;3]
fold
(fun ...)
[1;2;3]
fold
$(fun...)$
(1::[])
[2;3]
fold
$(fun...)$
[1]
[2;3]
fold
$(fun...)$
(2::[1])
[3]
fold
$(fun...)$
[2;1]
[3]
fold
$(fun...)$
(3::[2; 1])
[]
fold
$(fun...)$
[3;2;1]
[]
[3;2;1]
02157 Functional Programming, Week 4
33 of 38

[Page 71]Summary
Part I: Disjoint union (Algebraic data types)
- types containing different kinds of values
02157 Functional Programming, Week 4
34 of 38

[Page 72]Summary
Part I: Disjoint union (Algebraic data types)
types containing different kinds of values
We will later extend the notion with recursive definitions
provides a mean to declare types for finite trees
02157 Functional Programming, Week 4
34 of 38

[Page 73]Summary
Part I: Disjoint union (Algebraic data types)
types containing different kinds of values
We will later extend the notion with recursive definitions
provides a mean to declare types for finite trees
Part II: Higher-order list functions
• Many recursive declarations follows the same schema.
Succinct declarations achievable using higher-order functions
02157 Functional Programming, Week 4
34 of 38

[Page 74]Summary
Part I: Disjoint union (Algebraic data types)
types containing different kinds of values
We will later extend the notion with recursive definitions
provides a mean to declare types for finite trees
Part II: Higher-order list functions
• Many recursive declarations follows the same schema.
Succinct declarations achievable using higher-order functions
• Higher-order list functions (in the library)
★ map
contains, exists, forall, filter, tryFind
★ foldBack, fold
02157 Functional Programming, Week 4
34 of 38

[Page 75]Summary
Part I: Disjoint union (Algebraic data types)
types containing different kinds of values
We will later extend the notion with recursive definitions
provides a mean to declare types for finite trees
Part II: Higher-order list functions
• Many recursive declarations follows the same schema.
Succinct declarations achievable using higher-order functions
• Higher-order list functions (in the library)
★ map
contains, exists, forall, filter, tryFind
★ foldBack, fold
02157 Functional Programming, Week 4
Avoid (almost) identical code fragments by
parameterizing functions with functions
34 of 38

[Page 76]Exercises
• HR 4.18, on paper again understanding the type of a function, this time
higher order.
• Task 2 from Summer exam 2015
https://www.imm.dtu.dk/ mire/FSharpBook/oldExams.html
• As a larger program: an airport luggage system based on an old exam question.
See next slides.
02157 Functional Programming, Week 4
35 of 38

[Page 77]Exercises
Airport Luggage system
• Every piece of luggage is marked with an identification:
type Lid = string
• Each piece of lugagge will have a route, i.e. a list of flights and destination
airports:
type Flight = string
type Airport = string
type Route = (Flight * Airport) list
• A luggage catalogue of an airport associates with each piece of lugagge its
route as a pair of an Lid and a Route:
type LuggageCatalogue = (Lid * Route) list
An example of a luggage catalogue is
[("DL 016-914", [("DL 189","ATL"); ("DL 124","BRU"); ("SN 733","CPH")]);
("SK 222-142", [("SK 208", "ATL"); ("DL 124","BRU"); ("SK 122","JFK")])]
where first element in the list describes that the piece of luggage with identification
DL 016-914 is following a route, where it is first flown to Atlanta (ATL) with flight
DL 189, then flown to Bruxelles (BRU) with flight DL 124, and so on.
02157 Functional Programming, Week 4
36 of 38

[Page 78]Exercises
Airport Luggage system
For all the following functions you can give recursive definitions, but in each case
there is also an easy way to use instead the built-in higher-order functions on lists
like List.fold we discussed in the lecture.
 Declare a function findRoute: Lid -> LuggageCatalogue -> Route list,
that finds all route(s) for a given luggage identification in a luggage catalogue.
We use here a list of routes as result because the given Lid may not be found.
Also, if the luggage catalogue accidentally has several entries for the same Lid,
you may return all routes or just the first or stop with an error.
 Declare a function inRoute: Flight -> Route -> bool that decides whether
a given flight occurs in a route.
 Declare a function withFlight f 1c, where f is a flight and 1c is a luggage
catalogue. It returns a list of luggage identifiers for the pieces of luggage that
should travel with f according to 1c.
For the example catalogue, DL 124 gives both DL 016-914 and SK 222-142.
02157 Functional Programming, Week 4
37 of 38

[Page 79]Exercises
Airport Luggage system
An arrival catalogue associates with every airport the identifications of all pieces of
luggage that should arrive at the airport:
type ArrivalCatalogue
= (Airport * Lid list) list
For the example luggage catalogue, the arrival catalogue is:
[("ATL",
("JFK",
["DL 016-914"; "SK 222-142"]); ("BRU", ["DL 016-914"; "SK 222-142"]);
["SK 222-142"]); ("CPH", ["DL 016-914"])]
To compute it, declare the following functions  also these can be programmed
succinctly using higher-order list functions:
 insertLA lid ap ac takes an arrival catalogue ac and returns a new arrival
catalogue that is augmented by the fact that luggage lid will arrive at airport
ap. Note that you have to handle both the case that airport ap does not yet
occur in the given ac, and the case that it does.
 extend: Lid*Route -> ArrivalCatalogue -> ArrivalCalalogue so that
extend (lid, r) ac is the arrival catalogue obtained by extending ac with
the information that lid will arrive at each airport contained in route r.
This function can make good use of the function insertLA.
• Declare a function
toArrivalCatalogue: LuggageCatalogue -> ArrivalCatalogue, that
creates an arrival catalogue from the information of a given luggage catalogue.
This function can make good use the function extend.
02157 Functional Programming, Week 4
38 of 38