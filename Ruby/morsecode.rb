puts "Enter text to be translated"
input = gets.chomp.downcase
puts input

morse = [ ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....",
"..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", ".-.",
"-", "..-", "...-", ".--", "-..-", "-.--", "--.." ]

alpha = [ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'w', 'x', 'y', 'z' ]


for i in 0..(input.length-1)
    for j in 0..(alpha.length-1)
        if input[i] == alpha[j]
            puts morse[j]
        end
    end
end


