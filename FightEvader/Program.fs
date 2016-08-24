open System.IO

[<EntryPoint>]
let main argv = 
  try
    match argv.Length with
      | 1 | 2 ->
        use streamIn = new StreamReader(argv.[0])
        let arr = (streamIn.ReadToEnd ()).Split('\n')
        let rand = new System.Random()
        let swap (a: _[]) x y =
          let tmp = a.[x]
          a.[x] <- a.[y]
          a.[y] <- tmp
        Array.iteri (fun i _ -> swap arr i (rand.Next(i, Array.length arr)))
          arr
        
        if argv.Length > 1 then
          use streamOut = new StreamWriter(argv.[1])
          Array.iter (fun (s : string) -> streamOut.Write s) arr
          0
        else
          Array.iter (printf "%A\r\n") arr
          0
      | _ ->
        printfn "Usage: FightEvader.exe input_file [output_file]"
        0
  with
    | ex ->
      printfn "I/O error!\n%A" ex
      -1