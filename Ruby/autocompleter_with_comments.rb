class MatchFinder
  def initialize
    @word_list = ["a", "aardvark", "apple", "application"]
  end

  # returns true if the input string is an exact match
  # for the input
  def matches?(input_string)
    # Can this be replaced with @word_list.include?
    # If not, why?
    matches = false
    @word_list.each do |word|
      # puts "checking [#{word}], my input string is [#{input_string}]"
      if input_string == word
        # puts "this time it matches!"
        matches = true
      end
    end
    # puts matches
    return matches
  end
  
  # return a true or false based on if there are any
  # partial matches
  def partially_matches?(input_string)
    # true # this is the same as 'return true'
    matches = false
    @word_list.each do |word|
      # if word is hello, then
      #   ll does not match
      #   h does match
      #   hello does match
      if word.start_with?(input_string)
        matches = true
        # This will go over the whole array every time
        # Instead of stopping as soon as it finds a true
        # either return true here, or break?
      end
    end
    return matches
  end
  
  # returns an array containing beginning matches
  # if there aren't any matches, returns []
  def partial_matches_for(input_string)
    # Hey, this is really close to partially_matches?
    # Should partially_matches? call this then look at
    # a shared instance variable for length to return
    # true false? Is there some other way to reduce
    # the amount of repeated code?
    # ["aardvark", "apple"]
    matches_list = []
    @word_list.each do |word|
      if word.start_with?(input_string)
        # insert it into the answer that I'm going to return
        matches_list << word
      end
    end
    return matches_list
  end
end

puts "Enter a command or partial command!"
user_input = gets.chomp

matcher = MatchFinder.new

# hey, we don't use () in function calls if they don't need it
if matcher.matches?(user_input) # matches
  # remember, 3 spaces for an indent
  puts "hey, I recognized that! it was #{user_input}"
elsif matcher.partially_matches?(user_input)  # partially matches
  puts "Did you mean one of these?:"
  puts matcher.partial_matches_for(user_input)
else # doesn't exist
  puts "command unrecognized :("
end
