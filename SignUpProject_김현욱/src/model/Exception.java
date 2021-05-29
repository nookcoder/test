package model;

import javax.swing.*;

public class Exception {

	private Constants constants = new Constants();
	
	public boolean checkIdInput(String check) {
			
		if(!check.matches(constants.REGEX_TEXT_NUMBER))
		{
			return false;
		}

		return true;
	}
}
