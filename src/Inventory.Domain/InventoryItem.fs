namespace Inventory.Domain

module InventoryItem =

    type State = {
        isActive: bool
    } with 
        static member Zero = { isActive = false }

    type Command =
        | Create of string
        | Deactivate
    
    type Event =
        | Created of string
        | Deactivated
            
    //apply: State -> Event -> State
    let apply item event = 
        match event with 
            | Created _ -> { item with isActive = true }
            | Deactivated -> { item with isActive = false }
    
    //exec: State -> Command -> Event
    let exec item command = 
        let apply event = 
            apply item event |> ignore
            event
            
        match command with
            | Create(name) -> name |> Created |> apply
            | Deactivate -> Deactivated |> apply
        