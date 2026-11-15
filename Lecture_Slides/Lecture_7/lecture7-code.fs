type Tree<'a> = | Lf
                | Br of (Tree<'a>*'a*Tree<'a>)

let tr1=  Br(Br(Br(Lf,2,Lf),7,Lf),     9,     Br(Br(Lf,13,Lf),21,Br(Lf,25,Lf)))

// inorder :: Tree -> list<'a>
let rec inorder tr = 
  match tr with
  | Lf -> []
  | Br (l,n,r) -> inorder l @ [n] @ inorder r


// insert :: int -> Tree -> Tree
let rec insert i tr = 
  match tr with
  | Lf -> Br(Lf,i,Lf)
  | Br (l,n,r) ->
     if i=n then tr else
     if i<n then 
        let l' = insert i l 
        Br (l',n,r)
     else
        Br (l,n,insert i r)

let rec find i tr =
  match tr with
  | Lf -> false
  | Br (l,n,r) ->         
     if i=n then true else
     if i<n then 
        find i l 
     else
        find i r

let t1 = Br(Lf, 3, Br(Lf, 5, Lf));;
let t2 = insert 4 t1;;

// list2tree : int list -> Tree
let list2tree l = 
  List.fold (fun tr i -> insert i tr) Lf l

// insertSort : int list -> int list
let insertSort l =  inorder (list2tree l)

// contains :: int -> Tree -> bool
let rec contains i tr = ...

// Maps
type Mymap<'a,'b> = Tree<'a*'b>

// find : 'a -> Mymap<'a,'b> -> 'b
let rec find a map = ...

let rec insert a b map = 
  match map with
  | Lf -> Br(Lf,(a,b),Lf)
  | Br (l,(k,v),r) ->
     if a=k then Br (l,(a,b),r) else
     if a<k then 
        let l' = insert a b l 
        Br (l',(k,v),r)
     else
        Br (l,(k,v),insert a b r)


let toMap l = List.fold (fun m (a,b) -> insert a b m) Lf l


let testmap = toMap [("z",3); ("y",-1); ("x",2)]
find "x" testmap

// **** Expressions ****

type Fexpr =
  | Const of float
  | X
  | Add of Fexpr * Fexpr
  | Sub of Fexpr * Fexpr
  | Mul of Fexpr * Fexpr

// compute :: Fexpr -> float -> float
let rec compute fe x =
  match fe with
  | Const f -> f
  | X -> x 
  | Add (fe1,fe2) -> compute fe1 x + compute fe2 x
  | Sub (fe1,fe2) -> compute fe1 x - compute fe2 x
  | Mul (fe1,fe2) -> compute fe1 x * compute fe2 x

let test = compute (Mul(X, Add(Const 2.0, X))) 4.0

// substX: Fexpr -> Fexpr -> Fexpr
let rec substX eX e = 
  match e with
  | Const f -> Const f
  | X -> eX
  | Add (fe1,fe2) -> Add(substX eX fe1, substX eX fe2)
  | Sub (fe1,fe2) -> Sub(substX eX fe1, substX eX fe2)
  | Mul (fe1,fe2) -> Mul(substX eX fe1, substX eX fe2)

let ex = Add(Sub(X, Const 2.0), Mul(Const 4.0, X));;
let substex = substX (Mul(X,X)) ex;;

// D: Fexpr -> Fexpr
let rec D = function 
  | Const f -> Const 0.0
  | X -> Const 1.0
  | Add (fe1,fe2) -> Add(D fe1,D fe2)
  | Sub (fe1,fe2) -> Sub(D fe1,D fe2)
  | Mul (fe1,fe2) -> Add(Mul(D fe1,fe2),
                         Mul(fe1,D fe2))

let testderive = D (Mul(Const 3,Mul(X,X)))

// Variable number of sub-trees
type ListTree<'a> = Node of 'a * (ListTree<'a> list)

let t7 = Node(7,[]);; let t6 = Node(6,[]);;
let t5 = Node(5,[]);; let t3 = Node(3,[]);;
let t2 = Node(2,[t5]);; let t4 = Node(4,[t6; t7]);;
let t1 = Node(1,[t2; t3; t4]);;

// depth-first search
// dfs: ListTree<'a> list -> <'a> list
let rec dfs =
  function
  | [] -> []
  | Node(n,ts)::trest -> n::dfs(ts @ trest)

// breadth-first search
// bfs: ListTree<'a> list -> <'a> list
let rec bfs =
  function
  | [] -> []
  | Node(n,ts)::trest -> n::bfs(trest @ ts)
