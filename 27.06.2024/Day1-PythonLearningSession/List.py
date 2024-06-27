shopping_list = ["milk", "bread", "eggs"]

# Add an item to the list
shopping_list.append("cheese")

# Print the second item (using index 1)
print(shopping_list[1])

# Get a sublist from index 1 to 2 (excluding the element at index 2)
needed_items = shopping_list[1:2] 

# Remove the first item
shopping_list.remove("milk")

print(shopping_list) 
