package controller;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import view.CmdView;

public class CmdController {
	private CmdView view ;
	private File file; 
	private Scanner scanner = new Scanner(System.in);
	public CmdController(CmdView view) throws IOException {
		this.view = view;
		getStatement();
	}
	
	public void Init() throws IOException {
		view.showWindowsVersion();
		view.showRoute(getUserDirectory());
	}
	
	public String getUserDirectory() {
		String userDirectory; 
		userDirectory = System.getProperty("user.home");
		return userDirectory;
	}
	
	// 사용자에게 명령문 입력받기 
	public String getStatement() {
		String userStatement;
		userStatement = scanner.nextLine();
		userStatement = userStatement.trim(); 
		
		return userStatement;
	}

	// 사용자가 입력한 명령문 리스트로 만들기 
	public List<String> setStatementToArrayList(String userStatement) {
		String temp[];
		List<String> userStatementList = new ArrayList<String>();
		temp = userStatement.split(" ");
		
		for(int index=0;index<temp.length;index++)
		{
			if(!temp[index].trim().isEmpty()) 
			{
				userStatementList.add(temp[index]);
			}
		}
		
		return userStatementList;
	}
	
}
