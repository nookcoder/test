package controller;

import java.io.File;
import java.io.IOException;
import java.util.List;

import model.CmdModel;
import view.CmdView;

public class CdStatement {
	
	private CmdController controller;
	private CmdModel model;
	private CmdView view;
	
	public CdStatement(CmdView view, CmdController controller,CmdModel model)
	{
		this.view = view;
		this.controller = controller;
		this.model = model;
	}
	
	// 파일 경로 이동 
	public void goRoute(List<String> userStatementList) throws IOException
	{
		String pathName;
		
		pathName = controller.routeName + File.separator + userStatementList.get(1);
		
		if(model.isExistsFile(pathName))
		{
			controller.routeName = model.getFileRouteName(pathName);
			view.showRoute(controller.routeName);
		}
		
		else
		{
			view.showNoFindRoute();
			view.showRoute(controller.routeName);
		}
	}
	
	public String backOneRoute() throws IOException
	{
		int seperateIndex; 
		if(controller.routeName.equals("C:")||controller.routeName.equals("c:"))
		{
			return controller.routeName;
		}
		
		seperateIndex =controller.routeName.lastIndexOf(File.separator); 
		controller.routeName = controller.routeName.substring(0, seperateIndex);
		
		return controller.routeName;
	}
	
	public String backAllRoute()
	{
		controller.routeName = "C:"; 
		
		return controller.routeName;
	}
	
	public void runCdStatement(List<String> userStatementList) throws IOException
	{
		if(userStatementList.get(0).equals("cd")) 
		{
			
			goRoute(userStatementList);
		}
		
		else if(userStatementList.get(0).equals("cd..") || userStatementList.get(0).equals("cd..\\") || userStatementList.get(0).equals("cd../"))
		{
			if(userStatementList.size() > 1)
			{
			
				return;
			}
			backOneRoute();
			view.showRoute(controller.routeName);
		}
		
		else if(userStatementList.get(0).equals("cd..\\.."))
		{
			backOneRoute();
			backOneRoute();
			view.showRoute(controller.routeName);
		}
		
		else if(userStatementList.get(0).equals("cd\\"))
		{
			backAllRoute();
			view.showRoute(controller.routeName);
		}
		
		else
		{
			view.showRoute(controller.routeName);
		}
	}
	
	// 문자열에 . / \ 를 제외한 문자열이 있는 지 확인 
	public boolean isHavingText(List<String> userStatementList)
	{
		boolean isHaving = false;
		
		for(int index=1; index < userStatementList.size(); index++)
		{
			if(!deleteChar(userStatementList.get(index)).equals(null))
				isHaving = true;
		}
		
		return isHaving;
	}
	
	// 문자열에서 . \ / 삭제
	public String deleteChar(String str)
	{
		str = str.trim();
		str = str.replaceAll(".", "");	
		str = str.replaceAll("\\", "");
		str = str.replaceAll("/", "");
		
		return str;
	}
}
