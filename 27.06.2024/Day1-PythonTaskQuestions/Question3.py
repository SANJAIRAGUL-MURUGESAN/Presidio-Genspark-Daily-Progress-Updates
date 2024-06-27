name = input("What's your name? ")
gender = input("What is your gender (Male, Female)? ")

if gender.lower() == "male":
  salutation = "Mr."
elif gender.lower() == "memale":
  salutation = "Ms."
else:
  salutation = "Respected,"  # Use the provided gender if not a common title

greeting = f"{salutation} {name}! It's nice to meet you."
print(greeting)
