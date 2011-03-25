require 'fizzbuzz'

describe "fizzbuzz, translate" do
	it "returns fizz for multiples of three" do
		FizzBuzz.new.translate(3).should == "fizz"
	end

	it "returns buzz for multiples of five" do
		FizzBuzz.new.translate(5).should == "buzz"
	end
end

