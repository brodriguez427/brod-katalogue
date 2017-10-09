class MorseCode
    def convert letter
        result = ""
        letter.each_char do |char|
            @letter_convert.each do |alpha_letter|
            if char == alpha_letter[:morse_name]
                result << alpha_letter[:morse_value]
            end
        end
    end
    result
    end
    
        def initialize
        @letter_convert = []
            add_letter("a", ".- ")
            add_letter("b", "-... ")
            add_letter("c", "-.-. ")
            add_letter("d", "-.. ")
            add_letter("e", ". ")
            add_letter("f", "..-. ")
            add_letter("g", "--. ")
            add_letter("h", ".... ")
            add_letter("i", ".. ")
            add_letter("j", ".--- ")
            add_letter("k", "-.-. ")
            add_letter("l", ".-.. ")
            add_letter("m", "-- ")
            add_letter("n", "-. ")
            add_letter("o", "--- ")
            add_letter("p", ".--. ")
            add_letter("q", "--.- ")
            add_letter("r", ".-. ")
            add_letter("s", "... ")
            add_letter("t", "- ")
            add_letter("u", "..-")
            add_letter("v", "...- ")
            add_letter("w", ".-- " )
            add_letter("x", "-..- ")
            add_letter("y", "-.-- ")
            add_letter("z", "--.. ")
            add_letter(" ", " ")

        end

        def add_letter(name, value)
                @letter_convert << {morse_name: name, morse_value: value}
        end
        



        # if letter == "a"
        #     result = ".- "
        # end

        # if letter == "b"
        #     result = "-... "
        # end

    end
