type Lid = string
type Flight = string
type Airport = string
type Route = (Flight * Airport) list
type LuggageCatalogue = (Lid * Route) list

let exLC = 
  ([("DL 016-914", 
     [("DL 189","ATL"); ("DL 124","BRU"); ("SN 733","CPH")]);
    ("SK 222-142", 
     [("SK 208","ATL"); ("DL 124","BRU"); ("SK 122","JFK")])
   ])

// findRoute: Lid -> LuggageCatalogue -> Route option
let rec findRoute lid lc = 
  match lc with 
  | [] -> None
  | (l,r)::lc' -> if l=lid then Some r
                  else findRoute lid lc'

let (Some test1) = findRoute "DL 016-914" exLC

// inRoute: Flight -> Route -> bool
let rec inRoute fid route = 
  List.exists (fun (f,_) -> f=fid) route
  (*
  match route with
  | [] -> false
  | (f,a)::route' -> f=fid || inRoute fid route'
  *)

let test2 = inRoute "DL 189" test1

// withFlight : Flight -> Luggage Catalog -> Lid list
let rec withFlight f = 
  List.map fst <<
   (List.filter 
     (fun (lid,route) -> inRoute f route))
(*
  match lc with
  | [] -> []
  | (lid,route)::lc' ->
     let lids = withFlight f lc'
     if inRoute f route then lid::lids
     else lids
*)

let test3 = withFlight "DL 124" exLC

//type ArrivalCatalogue = (Airport * Lid list) list
type ArrivalCatalogue = Set<(Airport * Set<Lid>)>

// insert : Lid -> Airport -> 
//   ArrivalCatalogue -> ArrivalCatalogue
let rec insert lid ap ac = 
  if Set.exists (fun (a,ls) -> a=ap) ac
  then let f (a,lids) = 
              if (a=ap) 
              then (a,Set.add lid lids) 
              else (a,lids)
       Set.map f ac
  else Set.add (ap, set [lid] ) ac

let test4a = insert "DL 016-914" "BRU" Set.empty
let test4b = insert "SK 222-142" "BRU" test4a

// extend: Lid -> Route -> ArrivalCatalogue -> ArrivalCalalogue
let rec extend lid route ac = ...

let test5 = extend "DL 016-914" [("DL 189","ATL"); ("DL 124","BRU"); ("SN 733","CPH")] []

// toArrivalCatalogue: LuggageCatalogue -> ArrivalCatalogue
let rec toArrivalCatalogue lc = ...

let test6 = toArrivalCatalogue exLC

// Sets:

set ["Bob"; "Barbara"; "Ben"];;
set [3; 1; 9; 5; 7; 9; 1];;
set ["Bob";"Barbara";"Ben"] = set ["Barbara";"Ben";"Barbara";"Bob"];;
compare (set ["Ann";"Jane";"Dane"]) (set ["Ann";"Barbara";"Ben";"Bob"]);;

// Immutability:

let s = Set.ofList [3; 2; 0];;
Set.add 1 s;;
s;;
