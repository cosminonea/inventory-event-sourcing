namespace Inventory.Domain.Tests

open Xunit
open Inventory.Domain.InventoryItem

module InventoryItemTest = 

    

    [<Fact>]
    let ``should create an inventory item``() =
        let event = exec State.Zero (Create "item 1")
        Assert.Equal(Created "item 1", event)
    
    [<Fact>]
    let ``should deactivate``() =
        let state = apply State.Zero (Created "item 1")
        let event = exec state (Deactivate)
        
        Assert.Equal(Deactivated, event)
        
    [<Fact>]
    let ``should not deactivate an already inactive item``() =
        let state = apply State.Zero (Created "item 1")
        
        let state2 = apply state Deactivated
        
        Assert.Throws(fun() -> (exec state2 Deactivate) |> ignore)
