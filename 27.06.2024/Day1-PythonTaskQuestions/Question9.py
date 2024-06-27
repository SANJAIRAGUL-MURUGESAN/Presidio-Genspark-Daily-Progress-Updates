def all_permutations(string):
  if len(string) <= 1:
    return [string]

  permutations = []
  for i in range(len(string)):
    char = string[i]
    remaining_chars = string[:i] + string[i+1:]
    for permutation in all_permutations(remaining_chars):
      permutations.append(char + permutation)

  return permutations

# Example string
input_string = "abc"

# Get all permutations
permutations = all_permutations(input_string)

# Print the permutations
print("All permutations of", input_string, ":")
for permutation in permutations:
  print(permutation)
