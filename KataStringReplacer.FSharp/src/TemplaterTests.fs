module TemplaterTests

open Templater
open Xunit

[<Fact>]
let should_yield_empty_text_when_empty_text_is_provided () = 
  let text = subst "" []
  Assert.Equal<string>("", text)

[<Fact>]
let should_yield_text_when_text_is_passed_with_no_keywords () = 
  let text = subst "something" []
  Assert.Equal<string>("something", text)

[<Fact>]
let should_replace_key_with_value_when_key_was_found () = 
  let text = subst "hi $who$" [("who", "bingo")]
  Assert.Equal<string>("hi bingo", text)

[<Fact>]
let should_replace_multiple_keys_with_values_when_found () =
  let text = subst "$say$ $who$" [("who", "bingo");("say", "hello")]
  Assert.Equal<string>("hello bingo", text)

