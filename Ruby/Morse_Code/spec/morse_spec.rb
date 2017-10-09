require "morse"

describe MorseCode do
    describe ".convert" do
        context "when a is entered" do
            it "returns .- " do
                 message = MorseCode.new
               #  result = message.convert("a")
                 expect(message.convert("a")).to eql(".- ")
            end
        end
        context "when b is entered" do
            it "returns -... " do
                 message = MorseCode.new
                # result = message.convert("b")
                 expect(message.convert("b")).to eql("-... ")
            end 
        end

        context "when bb is entered" do
            it "returns -... -... " do
                 message = MorseCode.new
                # result = message.convert("bb")
                 expect(message.convert("bb")).to eql("-... -... ")
            end
        end
    end
end