package model;

import javax.swing.*;

public class Exception {

	private Constants constants = new Constants();
	
	public boolean checkIdInput(String check) {
		
		boolean isOk = true;
		
		if(!check.matches(constants.REGEX_TEXT_NUMBER))
		{
			isOk = false;
		}

		return isOk;
	}
}
