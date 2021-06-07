package controller;

import java.io.File;
import java.io.IOException;
import java.util.List;

import model.CmdModel;
import model.Constants;
import view.CmdView;

public class CdStatement {

	private CmdController controller;
	private CmdModel model;
	private CmdView view;
	private Constants constants;
	
	public CdStatement(CmdView view, CmdController controller,CmdModel model,Constants constants)
	{
		this.view = view;
		this.controller = controller;
		this.model = model;
		this.constants = new Constants();
	}

	// cd 명령문 실행 
	public void runCdStatement(List<String> userStatementList) throws IOException
	{
		// cd가 입력됐을때 
		if(userStatementList.get(constants.FIRST_COMMADN).equals("cd")) 
		{
			if(userStatementList.size() == constants.ONE_TEXT)
			{
				System.out.println(controller.routeName);
				System.out.print("\n");
				view.showRoute(controller.routeName);
				return;
			}
			runCd(userStatementList);
		}

		else if(userStatementList.get(constants.FIRST_COMMADN).equals("cd..") || userStatementList.get(0).equals("cd..\\") || userStatementList.get(0).equals("cd../"))
		{
			runCdDotDot(userStatementList);
		}

		else if(userStatementList.get(constants.FIRST_COMMADN).equals("cd..\\.."))
		{
			runCdDotBackSlash(userStatementList);
		}

		else if(userStatementList.get(constants.FIRST_COMMADN).equals("cd\\"))
		{
			runCdBackSlash(userStatementList);
		}

		else
		{
			view.showErrorStatement(userStatementList.get(constants.FIRST_COMMADN).toString());
			view.showRoute(controller.routeName);
		}
	}
	
	// cd 명령문 실행 
	public void runCd(List<String> userStatementList) throws IOException
	{
		// cd 뒤에 다른 명령어가 있을 때 
		if(userStatementList.get(constants.SECOND_COMMAND).equals(".."))
		{
			userStatementList.set(constants.FIRST_COMMADN, "cd..");
			userStatementList.remove(constants.SECOND_COMMAND);
			runCdDotDot(userStatementList);
			return;
		}
		else if(userStatementList.get(constants.SECOND_COMMAND).equals("..\\.."))
		{
			userStatementList.set(constants.FIRST_COMMADN, "cd..\\..");
			userStatementList.remove(1);
			runCdDotBackSlash(userStatementList);
			return;
		}
		
		else if(userStatementList.get(constants.SECOND_COMMAND).equals("\\"))
		{
			userStatementList.set(constants.FIRST_COMMADN, "cd\\");
			userStatementList.remove(constants.SECOND_COMMAND);
			runCdBackSlash(userStatementList);
			return;
		}
		
		// cd 뒤에 경로가 나올 때 
		goRoute(userStatementList);
	}

	// cd.. 명령문 실행 
	public void runCdDotDot(List<String> userStatementList) throws IOException
	{
		if(userStatementList.size() > constants.ONE_TEXT)
		{
			checkInputChar(userStatementList);
			return;
		}
		backOneRoute();
		view.showRoute(controller.routeName);
	}
	
	// cd..\.. 실행
	public void runCdDotBackSlash(List<String> userStatementList) throws IOException
	{
		if(userStatementList.size() > constants.ONE_TEXT)
		{
			checkInputChar(userStatementList);
			return;
		}
		backOneRoute();
		backOneRoute();
		view.showRoute(controller.routeName);
	}
	
	// cd\ 싱행 
	public void runCdBackSlash(List<String> userStatementList)
	{
		if(userStatementList.size() > constants.ONE_TEXT)
		{
			if(model.isHavingText(userStatementList))
			{
				view.showNoFindRoute();
				view.showRoute(controller.routeName);
			}
			
			else
			{
				backAllRoute();
				view.showRoute(controller.routeName);
			}
			return;
		}
		backAllRoute();
		view.showRoute(controller.routeName);
	}
	
	// cd 명령문 뒤에 .\/ 이외에 문자가 있으면 지정경로 오류 출력 
	public void checkInputChar(List<String> userStatementList)
	{
		if(model.isHavingText(userStatementList))
		{
			view.showNoFindRoute();
			view.showRoute(controller.routeName);
		}
		
		else
		{
			view.showRoute(controller.routeName);
		}
		return;
	}
	
	// 파일 경로 이동 
	public void goRoute(List<String> userStatementList) throws IOException
	{
		String pathName;
		
		pathName = model.makePath(userStatementList,controller.routeName,1);
		
		if(model.isExistsFile(pathName))
		{
			controller.routeName = pathName;
			view.showRoute(controller.routeName);
			return;
		}
		
		view.showNoFindRoute();
		view.showRoute(controller.routeName);
	}

	// 한칸 뒤로가기 
	public String backOneRoute() throws IOException
	{
		int seperateIndex; 
		if(controller.routeName.equals("C:")||controller.routeName.equals("c:"))
		{
			return controller.routeName;
		}

		seperateIndex = controller.routeName.lastIndexOf(File.separator); 
		controller.routeName = controller.routeName.substring(0, seperateIndex);

		return controller.routeName;
	}

	// 맨 처음으로 가기 
	public String backAllRoute()
	{
		controller.routeName = "C:"; 

		return controller.routeName;
	}
	
}
