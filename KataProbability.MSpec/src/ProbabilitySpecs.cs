namespace Kata {
  using System;
  using Machine.Specifications;

  class When_the_inversion_prob_of_prob_1_is_required {
    It should_return_0 = () => P.Of(1)
      .InverseOf()
      .ShouldEqual(P.Of(0));
  }

  public static class P {
    public static Probability Of(decimal value) {
      return new Probability(value);
    }
  }
}
