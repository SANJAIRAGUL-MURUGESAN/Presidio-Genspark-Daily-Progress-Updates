def length_of_longest_substring(s):

  used = {}  # store the index of the last seen character
  start = 0
  longest_substring = ""

  for i, char in enumerate(s):
    # If the character is already in used and within the current window
    if char in used and used[char] >= start:
      # Shift the starting index to the position after the last occurrence
      start = used[char] + 1
    else:
      # Update the longest_substring if the current window is longer
      if len(s[start:i + 1]) > len(longest_substring):
        longest_substring = s[start:i + 1]
    # Update the used dictionary
    used[char] = i

  return longest_substring

# Example usage abcabcbb
string = input("Enter the string : ")
longest_str = length_of_longest_substring(string)
print(f"The longest substring without repeating characters in '{string}' is: {longest_str}")
