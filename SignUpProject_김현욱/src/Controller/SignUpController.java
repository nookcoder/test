package Controller;

import java.awt.event.*;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.mysql.jdbc.*;

import model.Constants;
import model.MemberDataBase;
import model.Exception;
import view.SignUp;

public class SignUpController {

	private MemberDataBase member;
	private SignUp signup;
	private Constants constants;
	private Exception exception;
	
	public SignUpController(MemberDataBase member, SignUp signup)
	{
		this.exception= new Exception();
		this.constants = new Constants();
		this.member = member;
		this.signup = signup;
	}
	
	
}
