import java.util.ArrayList;
import java.util.List;

public class FizzBuzzRange {
	public List<String> Range(int from, int to) {
		List<String> translations = new ArrayList<String>();
		
		for (int i=from; i<=to; i++)
			translations.add(null);
		
		return translations;
	}
}
