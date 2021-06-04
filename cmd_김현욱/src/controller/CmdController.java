package controller;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import model.CmdModel;
import view.CmdView;

public class CmdController {
	private CmdView view ;
	private CmdModel model;
	private CdStatement cdStatement; 
	private DirStatement dirStatement;
	private Scanner scanner = new Scanner(System.in);
	
	public String routeName ; 
	
	public CmdController(CmdView view,CmdModel model) throws IOException {
		this.view = view;
		this.model = model;
		this.cdStatement = new CdStatement(view,this,model);
		this.dirStatement = new DirStatement(view, this, model);
		this.routeName = getUserDirectory(); 
		Init();
	}
	
	// 처음 실행시킬 함수
	public void Init() throws IOException {
		String statement;
		List<String> userStatementList;
		
		setInitView();
		while(true)
		{
			statement = getStatement();
			if(statement.length() != 0)
			{
				userStatementList = setStatementToArrayList(statement);
				if(userStatementList.get(0).contains("cd"))
				{
					cdStatement.runCdStatement(userStatementList);
				}
				
				else if(userStatementList.get(0).contains("dir"))
				{
					dirStatement.runDirStatement(userStatementList);
				}
				
				else if(userStatementList.get(0).contains("cls"))
				{
					if(isExecuteClear(userStatementList.get(0)))
					{
						view.showClear();
						view.showRoute(routeName);
					}
					
					else
					{
						view.showErrorStatement(userStatementList.get(0));
						view.showRoute(routeName);
					}
				}
			}
			
			else
			{
				view.showRoute(routeName);
			}
		}
		
	}
	
	// cmd 실행 시 처음 화면 출력 
	public void setInitView() throws IOException {
		view.showWindowsVersion();
		view.showRoute(routeName);
	}
	
	// 유저 파일 불러오기 
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
	
	public boolean isExecuteClear(String statement)
	{
		boolean isClear = false;
		if(statement.charAt(0) == 'c' && statement.charAt(1) == 'l' && statement.charAt(2) == 's')
		{
			if(statement.length() == 3 || statement.charAt(3) == '&'|| statement.charAt(3) == '(' || statement.charAt(3) == '=' || statement.charAt(3) == '+'
					|| statement.charAt(3) == '['|| statement.charAt(3) == ']'||statement.charAt(3) == ';' || statement.charAt(3) == ':' || statement.charAt(3) == '.'
					|| statement.charAt(3) == ',' || statement.charAt(3) == '.' || statement.charAt(3) == '\\')
			{
				isClear = true;
			}
		}
		
		return isClear;
	}
	
}
