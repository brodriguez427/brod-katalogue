class MatchFinder
  def initialize
    @word_list = ["a", "aardvark", "apple", "application"]
  end

  # returns true if the input string is an exact match
  # for the input
  def matches?(input_string)
    @word_list.include? input_string
  end
  
  # returns an array containing beginning matches
  # if there aren't any matches, returns []
  def partial_matches_for(input_string)
    # ["aardvark", "apple"]
    @word_list.select do |word|
      word.start_with?(input_string)
    end
  end
end

puts "Enter a command or partial command!"
user_input = gets.chomp

matcher = MatchFinder.new

if matcher.matches? user_input # matches
  puts "hey, I recognized that! it was #{user_input}"
else
  matches = matcher.partial_matches_for user_input
  if matches.empty? # doesn't match
    puts "command unrecognized :("
  else # partially matches
    puts "Did you mean one of these?:"
    puts matches
  end
end

# John's commentary & how I addressed it:

# Can this be replaced with @word_list.include?
# If not, why?
#
# Changed matches? to use include?
# reduced to one line!

# Hey, this is really close to partially_matches?
# Should partially_matches? call this then look at
# a shared instance variable for length to return
# true false? Is there some other way to reduce
# the amount of repeated code?
#
# I removed partially_matches? and replaced with a change
# in the main program logic to save the return from
# partial_matches_for in an array, which I then check to see
# if it's empty or not.

# hey, we don't use () in function calls if they don't need it
#
# removed parentheses from function calls

# remember, 3 spaces for an indent
#
# no.

# Can we just replace this with a collect fn?
# Something like:
#   matches_list.collect(_.starts_with(input_string))
#
# addressed in partial_matches_for.
# see https://ruby-doc.org/core-2.4.2/Enumerable.html#method-i-select
