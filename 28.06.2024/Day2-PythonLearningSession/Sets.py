# Sets are used to store multiple items in a single variable.
# A set is a collection which is unordered, unchangeable*, and unindexed.

#Creating and Printing Sets
thisset = {"apple", "banana", "cherry"}
print(thisset)

#Accessing set
thisset = {"apple", "banana", "cherry"}
for x in thisset:
  print(x)

#Checks for certain value
thisset = {"apple", "banana", "cherry"}
print("banana" in thisset)

#Adding valus in Set
thisset = {"apple", "banana", "cherry"}
thisset.add("orange")
print(thisset)

#Adding values in one set to other set
thisset = {"apple", "banana", "cherry"}
tropical = {"pineapple", "mango", "papaya"}
thisset.update(tropical)
print(thisset)

#Removing Set Items - If element does not exist, it will raise a error
thisset = {"apple", "banana", "cherry"}
thisset.remove("banana")
print(thisset)

#Removing Set Items - If element does not exist, it will not araise a error
thisset = {"apple", "banana", "cherry"}
thisset.discard("banana")
print(thisset)

#pop() - removes random item
thisset = {"apple", "banana", "cherry"}
x = thisset.pop()
print(x)
print(thisset)

# To Clears method emties the set
thisset = {"apple", "banana", "cherry"}
thisset.clear()
print(thisset)

# To Delete the set
thisset = {"apple", "banana", "cherry"}
del thisset
print(thisset)

#Set Looping
thisset = {"apple", "banana", "cherry"}
for x in thisset:
  print(x)

#Set Union
set1 = {"a", "b", "c"}
set2 = {1, 2, 3}
set3 = set1.union(set2)
print(set3)

#Joins multiple set
set1 = {"a", "b", "c"}
set2 = {1, 2, 3}
set3 = {"John", "Elena"}
set4 = {"apple", "bananas", "cherry"}
myset = set1.union(set2, set3, set4)
print(myset)

#set intersection
set1 = {"apple", "banana", "cherry"}
set2 = {"google", "microsoft", "apple"}
set3 = set1.intersection(set2)
print(set3)

#set difference
set1 = {"apple", "banana", "cherry"}
set2 = {"google", "microsoft", "apple"}
set3 = set1.difference(set2)
print(set3)

#set symmetric difference
set1 = {"apple", "banana", "cherry"}
set2 = {"google", "microsoft", "apple"}
set3 = set1.symmetric_difference(set2)
print(set3)