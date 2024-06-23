class Person
{
    startWalking()
    {
        console.log("Person starts walking from his home")
    }
    reachedGroceryShop()
    {
        this.startWalking()
        console.log("Reached the grocery shop")
    }
}

let ram=new Person()
ram.reachedGroceryShop()