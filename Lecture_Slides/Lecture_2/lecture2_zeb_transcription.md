02157 Functional Programming
Week 2: Functions, Types, and Lists
Sebastian Mödersheim
Based on slides by Michael Reichhardt Hansen
September 11, 2026
02157 Functional Programming, Week 2 1 of 39

Outline
1 Recap: What we have seen of F# so far
2 Last Week's Exercises
3 Intro to Types
4 Intro to Higher-Order Functions
5 Lists
6 On functional decomposition
7 Exercises
02157 Functional Programming, Week 2 2 of 39

Syntax, Type Checking, and Semantics
• The syntax of a programming language describes what sequences of characters consitute a correctly formed program,
★ e.g. balancing of opening and closing parentheses.
• Type checking checks that all values (including functions) used in the program are indeed defined and used with the correct types,
★ e.g. a function that expects an int cannot be called with a string.
• Semantics says what a syntactically correct, well-typed program means.
★ e.g. if $x>0$ then x else $2*x$ with $[x\mapsto-3]$ evaluates to -6.
• In 02141 Computer Science Modelling you will learn how to formally describe syntax and semantics of programming languages.
• During the course, we will make such descriptions for reference, but not in all details formally. You will not be asked in the exam to describe syntax or semantics of F#.
02157 Functional Programming, Week 2 3 of 39

The Syntax unlocked so far (1/3):
Constants
• int constants like 0, 1, -1, ...
• float constants like 0.0, 3.14, ...
• string constants like "Hello"
• bool constants true and false
Identifiers
are programmer-chosen names for variables and functions, like x7 or exp. They are sequences of alphanumberic characters (letters and digits), where the first must be a letter.
Keywords of F# like let also fulfill the definition of an identifier, but cannot be used as variable or function names, of course.
In compiler construction one typically formalizes concepts like constants and identifiers by regular expressions like IDENT: [a-zA-Z] [a-zA-Z0-9]*
but we do not go into that in this course.
02157 Functional Programming, Week 2 4 of 39

The Syntax unlocked so far (2/3):
Expressions
An expression can be any of the following:
• A constant
• An identifier
• If e, $e_{1},...e_{n}$ are expressions and is an infix operator (like $+,*,<,=,...$), then also the following are expressions:
★ $e_{1}e_{2}$
★ if e then $e_{1}$ else $e_{2}$
★ (e)
★ $e_{1}$ $e_{2}$
★ $(e_{1},...,e_{n})$

Examples:
• $3*x+7$ This is equivalent to $(3*x)+7$ (operator * binds stronger than +)
• sqrt 2 This is normal function application
sqrt(2) is also correct, but not necessary.
• sqrt 2 * sqrt 2 This is equivalent to (sqrt 2) * (sqrt 2) (standard function application binds stronger than infix operators)
• x * if $x>0$ then 3 else -1

Note that this is an inductive definition:
• it defines some atomic expressions (constants, identifiers)
• and how larger expressions can be composed from smaller ones.
In compiler construction, one typically uses context-free grammars to express such inductive definitions, e.g.,
expr ::= CONST | IDENT | expr INFIXOP expr | if expr then expr else expr | ...
but we do not go into that in this course.
02157 Functional Programming, Week 2 5 of 39

The Syntax unlocked so far (3/3):
Declarations
If e is an expression and f and $x_{1},...,x_{n}$ are identifiers, then the following are declarations:
• let $f=e$
• let f $(x_{1},...,x_{n})=e$
• let rec $f=e$
• let rec $f(x_{1},...,x_{n})=e$
Each of these define a function or value f by the expression e where
• Keyword rec must be used, if the definition is recursive, i.e., if f occurs in e.
• In the cases with $(x_{1},...,x_{n})$, f is a function that takes an n-tuple as input and e may contain the $x_{i}$.

Example
let rec pow $(x,n)=$ if $n=0$ then 1.0 else x * pow (x,n-1)

That is the syntax we unlocked with the first example!
This is already Turing complete (with unbounded memory).
02157 Functional Programming, Week 2 6 of 39

Patterns
We had also seen pattern matching as a way to describe case distinction nicely, for instance:
let rec power (x,n) =
match (x,n) with
| (_,0) -> 1.0 (* 1 *)
| (x,n) -> x * power(x,n-1) (* 2 *)

Patterns
A pattern can be any of the following:
• A constant
• An identifier
• The wildcard
• If $p_{1},...p_{n}$ are patterns, then also $(p_{1},...,p_{n})$ is a pattern.

Expressions
An expression can also be:
match e with
| $p_{1}\rightarrow e_{1}$
...
| $p_{n}\rightarrow e_{n}$
if $p_{1},...,p_{n}$ are patterns and e, $e_{1},...,e_{n}$ are expressions.

Unlocking: we will extend the concepts of expressions, patterns, and declarations, during the course with every feature we discuss.
02157 Functional Programming, Week 2 7 of 39

Outline
1 Recap: What we have seen of F# so far
2 Last Week's Exercises
3 Intro to Types
4 Intro to Higher-Order Functions
5 Lists
6 On functional decomposition
7 Exercises
02157 Functional Programming, Week 2 8 of 39

Exercises
Recursive Functions:
• Hansen and Rischel Book (HR):
Exercise 1.4: Define a function f with $f(n)=1+2+...+n$.
Exercise 1.6: Define a function sum such that
$sum(m,n)=m+(m+1)+...+(m+n-1)+(m+n)$
Exercise 2.8: Define $\binom{n}{k}$ where $0\le k\le n$ according to the definition:
$\binom{n}{0}=\binom{n}{n}=1$
$\binom{n}{k}=\binom{n-1}{k}+\binom{n-1}{k-1}$
02157 Functional Programming, Week 2 9 of 39

Outline
1 Recap: What we have seen of F# so far
2 Last Week's Exercises
3 Intro to Types
4 Intro to Higher-Order Functions
5 Lists
6 On functional decomposition
7 Exercises
02157 Functional Programming, Week 2 10 of 39

Introduction to Types
F# is a typed language:
• Every value is supposed to have a type (like int).
• There are typing rules that specify what is a type-correct expression, declaration, or pattern.
★ This is a restriction on the syntactically correct expressions
★ e.g. $3*3.1$ is syntactically correct, but a type error (multiplying an int with a float).
• You (normally) do not specify types, but the F# interpreter or compiler will try to infer them for you.
• When F# tools report a type error, it almost always represents a real problem in your program: you specified something you don't want.
02157 Functional Programming, Week 2 11 of 39

Types
A type can be any of the following:
• Basic types: int, float, bool, string ...
• Tuples: $\tau_{1}*...*\tau_{n}$ where the $\tau_{i}$ are already types
• Functions: $\tau_{1}\rightarrow\tau_{2}$ where $\tau_{1}$ and $\tau_{2}$ are types
• Later we also have type variables and type constructors
For instance we have power: float*int -> float
Generally e: $\tau$ means expression e is of type $\tau$.
02157 Functional Programming, Week 2 12 of 39

Basic Typing Rules
N.B.: Defining a typing system is involved, we simplify matters here.
Constants
Constants have basic types that are recognized directly:
• e.g. 3:int, 3.14: float, true:bool ...

Built-in Infix Functions
$e_{1}$: int, $e_{2}$: int -> $e_{1}+e_{2}$: int
$e_{1}$: float, $e_{2}$: float -> $e_{1}+e_{2}$: float
$e_{1}$: int, $e_{2}$: int -> $e_{1}=e_{2}$: bool
$e_{1}$: int, $e_{2}$: int -> $e_{1}<e_{2}$: bool

Variables/Identifiers
Usually type not given. It is the task of type inference to figure out a type that fits.
E.g. in $x+3.1$ we have that 3.1: float and + works only if both arguments have the same type, so x: float.
02157 Functional Programming, Week 2 13 of 39

Basic Typing Rules
Conditionals
The expression if $e_{0}$ then $e_{1}$ else $e_{2}$ is only type correct if:
• $e_{0}$: bool
• There is some type $\tau$ such that both $e_{1}: \tau$ and $e_{2}: \tau$
The expression has then type $\tau$.

Example: if $n>0$ then 1.0 else x
Is this type correct, and what types must n and x have?

Tuples
For expressions $e_{1}:\tau_{1},...,e_{n}:\tau_{n}$:
$(e_{1},...,e_{n}):\tau_{1}*...*\tau_{n}$
02157 Functional Programming, Week 2 14 of 39

Basic Typing Rules
Patterns
Typing of patterns works just like typing of expressions where a wildcard is replaced with a fresh variable name.

Pattern Matching
The expression
match e with
| $p_{1}\rightarrow e_{1}$
...
| $p_{n}\rightarrow e_{n}$
is type correct if the following holds:
• The expression e must have the same type as the patterns:
There is some type $\tau_{0}$ such that $e:\tau_{0}$ and $p_{1}:\tau_{0},...p_{n}:\tau$
• All the results for each case must have the same type:
There is some type $\tau$ such that $e_{1}:\tau,...,e_{n}:\tau$
The entire match expression has then type $\tau$.
02157 Functional Programming, Week 2 15 of 39

Basic Typing Rules
Declarations
If $e:\tau$ for some type $\tau$, then the declaration
let rec $v=e$
implies that also $v:\tau$.
If $e:\tau$ for some type $\tau$ and $p:\tau_{0}$ then
let rec f p = e
implies that $f:\tau_{0}\rightarrow\tau$

In recursive function declarations like power, the type inference has to figure out types $\tau$ and $\tau_{0}$ so that this rule is satisfied.

Example: Infer the type of power
let rec power $(x,n)=$
match n with
| 0 -> 1.0
| _ -> x * power(x,n-1)
02157 Functional Programming, Week 2 16 of 39

Outline
1 Recap: What we have seen of F# so far
2 Last Week's Exercises
3 Intro to Types
4 Intro to Higher-Order Functions
5 Lists
6 On functional decomposition
7 Exercises
02157 Functional Programming, Week 2 17 of 39

Higher-Order Functions
Idea
Functions are values
• In conventional languages, often only data can be argument or result of a function (e.g., int, or int-array).
• In functional languages, also functions (computations) can be argument or result of a function.
• We call a function higher-order, if it has a function as argument or result.
02157 Functional Programming, Week 2 18 of 39

fun
Function Expressions
Let x be a variable of type $\tau_{0}$ and e be an expression of type $\tau$. Then also
fun x -> e
is an expression that defines a function that takes an x and returns e. Thus, the resulting expression is of type $\tau_{0}\rightarrow\tau$.

Example: what is the type of this?
let rec powerC =
fun x ->
fun n ->
match n with
| 0 -> 1.0
| _ -> x * ( powerC x (n-1) )

For comparison:
let rec power (x,n) =
match n with
| 0 -> 1.0
| _ -> x * power(x,n-1)

power: float * int -> float
powerC: float -> int -> float
02157 Functional Programming, Week 2 19 of 39

Some Syntactic Sugar
Since we often need this we have some syntactic sugar, i.e., abbreviating notation:

Function Declaration
let rec f $p_{1}...p_{n}=e$
is an abbreviation for:
let rec f = fun $p_{1}$ -> ... fun $p_{n}\rightarrow e$

Thus we can simply write
let rec powerC x n =
match n with
| 0 -> 1.0
| _ -> x * ( powerC x (n-1) )

For comparison:
let rec power (x,n) =
match n with
| 0 -> 1.0
| _ -> x * power(x,n-1)

power : float * int -> float
powerC : float -> int -> float

But what's the advantage of this?
02157 Functional Programming, Week 2 20 of 39

Comparison: tuple vs. higher-order function
// powerC: float -> (int -> float)
let rec powerC x n =
match n with
| 0 -> 1.0
| _ -> x * ( powerC x (n-1) )

• the argument of powerC is the base x
• and powerC x is the function that maps exponent n to $x^{n}$

The function may be evaluated in stages:
let pow2 = powerC 2.0;;
pow2 3;;
val it : float = 8.0
pow2 4;;
val it : float = 16.0
02157 Functional Programming, Week 2 21 of 39

Higher-Order Functions
General Idea
• Instead of a function that takes an n-tuple of arguments
$f : \tau_{1} * ... \tau_{n} \rightarrow \tau$
• you can have a higher-order function that evaluates in n stages of one argument:
$fC : \tau_{1} \rightarrow \tau_{2} \rightarrow ... \tau_{n} \rightarrow \tau$
• Idea due to Moses Schönfinkel and Haskell Curry
★ Hence they are called schönfinkeled or curried functions.

This allows often for very elegant programs, so typically people define functions curried in functional languages.

Example:
let cube x = powerC x 3
02157 Functional Programming, Week 2 22 of 39

Outline
1 Recap: What we have seen of F# so far
2 Last Week's Exercises
3 Intro to Types
4 Intro to Higher-Order Functions
5 Lists
6 On functional decomposition
7 Exercises
02157 Functional Programming, Week 2 23 of 39

Lists
A list is a finite sequence of elements having the same type:
$[v_{1};...;v_{n}]$ ([] is called the empty list)

[2;3;6];;
val it : int list = [2; 3; 6]

["a"; "ab"; "abc"; ""];;
val it : string list = ["a"; "ab"; "abc"; ""]

[sin; cos];;
val it : (float->float) list = [<fun:...>; <fun:...>]

[(1,true); (3,true)];;
val it : (int * bool) list = [(1, true); (3, true)]

[[]; [1]; [1;2]];;
val it : int list list = [[]; [1]; [1; 2]]
02157 Functional Programming, Week 2 24 of 39

List constructors
The formal definition of lists:

Lists
A list (with elements of type $\tau$) can be constructed as follows:
• [] (the empty list)
• If e is an expression (of type $\tau$) and l is a list (with elements of type $\tau$), then also e :: l is a list with elements of type $\tau$.

Lists are also expressions.
Lists are homogenous, i.e., all elements are of the same (arbitrary) type $\tau$.
The list type is thus called $\tau$-list.

The notation $[x_{1}; x_{2}; ... ; x_{n}]$ is just a syntactic sugar for $x_{1}::x_{2}:: ...::x_{n}::[]$.
The constructor :: is pronounced cons

For a non-empty list $[x_{1}; x_{2}; ... ; x_{n}], n \ge 1$, we call
• $x_{1}$ the head and
• $[x_{2}; ... ; x_{n}]$ the tail.
There are library functions List.head and List.tail.
02157 Functional Programming, Week 2 25 of 39

Lists for Pattern Matching
Pattern matching (for Lists)
Let $p_{1}$ and $p_{2}$ be patterns, then also the following are patterns:
• [] matching only the empty list
• $p_{1} :: p_{2}$ matching only a list with at least one element, where
★ the head matches $p_{1}$ (of some type $\tau$)
★ and the tail matches $p_{2}$ (of type $\tau$ list)
02157 Functional Programming, Week 2 26 of 39

Recursion on lists – a simple example
$suml [x_{1};x_{2}; ... ;x_{n}] = \sum_{i=1}^{n} x_{i} = x_{1} + x_{2} + ... + x_{n} = x_{1} + \sum_{i=2}^{n} x_{i}$

Constructors are used in list patterns
let rec suml xs =
match xs with
| [] -> 0
| x::tail -> x + suml tail
val suml : int list -> int

suml [1;2]
$\leadsto 1 + suml [2]$ ($x \mapsto 1$ and $tail \mapsto [2]$)
$\leadsto 1 + (2 + suml [])$ ($x \mapsto 2$ and $tail \mapsto []$)
$\leadsto 1 + (2 + 0)$ (the pattern [] matches the value [])
$\leadsto 1 + 2$
$\leadsto 3$

Recursion follows the structure of lists
02157 Functional Programming, Week 2 27 of 39

A polymorphic list function (I)
The function remove y xs gives the list obtained from xs by deleting every occurrence of y, e.g. remove 2 [1; 2; 0; 2; 7] = [1; 0; 7].
Recursion is following the structure of the list:

let rec remove y xs =
match xs with
| [] -> []
| x::tail when x=y -> remove y tail
| x::tail -> x::remove y tail

List elements can be of any type that supports equality
remove : 'a -> 'a list -> 'a list when 'a : equality
• 'a is a type variable. I usually prefer to write $\alpha, \tau, ...$
• 'a : equality is a type constraint
★ we can only apply remove to $\alpha$ lists, if equality is defined on $\alpha$, e.g. int, string, . . . but not functions.
The F# system infers the most general type for remove
02157 Functional Programming, Week 2 28 of 39

A polymorphic list function (II)
• A type containing type variables is called a polymorphic type
• The remove function is called a polymorphic function.
remove : 'a -> 'a list -> 'a list when 'a : equality

The function has many forms, one for each instantiation of 'a:
Instantiating 'a with int:
remove 2 [1; 2; 0; 2; 7];;
val it : int list = [1; 0; 7]

Instantiating 'a with int list:
remove [2] [[2;1]; [2]; [0;1]; [2]; [5;6;7]];;
val it : int list list = [[2; 1]; [0; 1]; [5; 6; 7]]

Notice that -> associates to the right:
'a -> 'a list -> 'a list means 'a -> ('a list -> 'a list)
02157 Functional Programming, Week 2 29 of 39

Exploiting structured patterns: the isPrefix function
The function isPrefix xs ys tests whether the list xs is a prefix of the list ys, for example:
isPrefix [1; 2; 3] [1; 2; 3; 8; 9] = true
isPrefix [1; 2; 3] [1; 2; 8; 3; 9] = false

The function is declared as follows:
let rec isPrefix xs ys = // Each clause expresses
match (xs,ys) with // a natural property:
| ([],_) -> true // [] is prefix of any list
| (_,[]) -> false // non-empty list is not prefix of []
| (x::xtail,y::ytail) -> // non-empty is prefix of non-empty
x=y && // if first element equal and
isPrefix xtail ytail // rests are in prefix relation

isPrefix [1;2;3] [1;2];;
val it : bool = false
02157 Functional Programming, Week 2 30 of 39

Summary
• Lists
• Polymorphism
• Constructors (:: and [] for lists)
• Patterns
• Recursion on the structure of lists
• Constructors used in patterns to decompose structured values
• Constructors used in expressions to compose structured values
02157 Functional Programming, Week 2 31 of 39

Outline
1 Recap: What we have seen of F# so far
2 Last Week's Exercises
3 Intro to Types
4 Intro to Higher-Order Functions
5 Lists
6 On functional decomposition
7 Exercises
02157 Functional Programming, Week 2 32 of 39

Functional decomposition
A simple technique when solving a complex problem is
• to partition it into smaller well-defined parts and, thereafter,
• to compose these parts to solve the original problem.
The main goal is that a program is constructed by
• combining simple well-understood pieces
Invent useful helper functions
02157 Functional Programming, Week 2 33 of 39

Functional decomposition: Example 1
Sorting a list: sort: 'a list -> 'a list when 'a : comparison.
Insertion in an ordered list is easy:

(* insert:'a -> 'a list -> 'a list when 'a : comparison *)
let rec insert x ys =
match ys with
| [] -> [x]
| y::_ when x <= y -> x::ys
| y::ytail -> y::insert x ytail

Insertion sort can now easily be implemented:
let rec sort xs =
match xs with
| [] -> []
| x::xtail -> insert x (sort xtail)

• small comprehensible programs
Notice: there are better sorting algorithms than insertion sort
02157 Functional Programming, Week 2 34 of 39

Idea: mergesort
Idea mergesort:
• Use recursion for sorting.
• To sort a list, one could split it into two smaller parts of half the size and sort the parts recursively.
• Then we just need to merge the two sorted parts into one sorted list.
• What is the base case of the recursion, i.e., where no further recursion is necessary?
• What's the runtime of mergesort?
02157 Functional Programming, Week 2 35 of 39

Functional decomposition: Example 2
Consider multiplication of polynomials:
$0\cdot Q(x)=0$
$(a_{0}+a_{1}\cdot x+...+a_{n}\cdot x^{n})\cdot Q(x):=a_{0}\cdot Q(x)+x\cdot((a_{1}+a_{2}\cdot x+...+a_{n}\cdot x^{n-1})\cdot Q(x))$

Idea
Represent polynomes by a list of coefficients:
type Poly = int list defines a new type Poly
• [1; 2; 3] represents $1+2x+3x^{2}$
• [2; 0; 0; 1] represents $2+x^{3}$
• General: $[a_{0};...;a_{n}]$ for $a_{0}+a_{1}x+a_{2}x^{2}+...+a_{n}x^{n}$

Invent suitable auxiliary functions
• mulC: int -> Poly -> Poly — for multiplying a polynome by a constant
e.g. mulC 3 [1;2;3] = [3;6;9]
• mulX: Poly -> Poly — for multiplying a polynome $P(x)$ by its variable x
e.g. mulX [1;2;3] = [0;1;2;3]
• add: Poly -> Poly -> Poly — for adding two polynomes
e.g. add [1;2;3] [0;1] = [1;3;3]
With these helpers define mul: Poly -> Poly -> Poly by the equation above.
e.g. mul [2;3;0;1] [1;2;3]= [2;7;12;10;2;3]
02157 Functional Programming, Week 2 36 of 39

Invent helper function(s): Blackboard exercise
Declare a function sumProd: int list -> int*int:
sumProd $[x_{0};x_{1}; ...;x_{n-1}]$ = $( x_{0} + x_{1} + ... + x_{n-1} , x_{0} * x_{1} * ... * x_{n-1} )$
sumProd [] = (0,1)
02157 Functional Programming, Week 2 37 of 39

Outline
1 Recap: What we have seen of F# so far
2 Last Week's Exercises
3 Intro to Types
4 Intro to Higher-Order Functions
5 Lists
6 On functional decomposition
7 Exercises
02157 Functional Programming, Week 2 38 of 39

Exercises
• HR 1.5: the Fibonacci numbers
$F_{0} = 0$
$F_{1} = 1$
$F_{n} = F_{n-1} + F_{n-2}$ for $n > 1$
• HR 2.2: $pow(s, n) = s \cdot s \cdot ... \cdot s$ for string s and int n.
• HR 4.7: multiplicity x xs – compute the number of times x occurs in xs.
• Polynome exercise from slide 36 ($\approx$ HR 4.22).
• Merge sort: idea explained in class on blackbord
Define helper functions (they are all in the List library, but easy to write yourself):
★ length: 'a list->int length of a list
e.g. length [1;2;3] = 3
★ split: int->'a list->('a list,'a list) split a list into two after a given number of elements
e.g. split 2 [1;2;3;4;5] = ([1;2],[3;4;5])
★ merge: ('a list,'a list) -> 'a list merge a pair of sorted lists into one sorted list.
Put it together into mergesort.
02157 Functional Programming, Week 2 39 of 39