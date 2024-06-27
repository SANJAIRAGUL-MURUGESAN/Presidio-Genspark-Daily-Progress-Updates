# Input 1
# Taking input from the user as string
name = input("What is your name? ")
# Output
print("Hello, " + name + "!")

# Input 2
# Taking input from the user as integer
num = int(input("Enter a number:"))
add = num + 1
print(add)

# Input 3
# Taking input from the user as float
num =float(input("Enter a number "))
add = num + 1
print(add)

# Input 4
# Taking input from the user as list, (Example Input : 12345)
list =list(input("Enter number ")) 
print(list)

# Input 5
# Taking input from the user as tuple, (Example Input : 12345)
num =tuple(input("Enter number "))
print(num)

# Input 6
words_str = input("Enter a list of words, separated by spaces: ")
words = {word: len(word) for word in words_str.split()}
print(words)

