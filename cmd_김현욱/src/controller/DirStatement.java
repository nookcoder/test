package controller;

import java.io.File;
import java.io.IOException;
import java.util.List;


import model.CmdModel;
import view.CmdView;

public class DirStatement {
	private CmdView view;
	private CmdController controller;
	private CdStatement cd; 
	private CmdModel model;
	
	public DirStatement(CmdView view, CmdController controller,CmdModel model)
	{
		this.view = view;
		this.controller = controller;
		this.model = model;
	}
	
	public void runDirStatement(List<String> userStatementList) throws IOException
	{
		String routeName = controller.routeName;
		
		if(userStatementList.get(0).equals("dir"))
		{
			if(userStatementList.size()>1)
			{
				runDir(userStatementList,routeName);
				return;
			}
			showDirectory(routeName);
		}
		
		else if(userStatementList.get(0).equals("dir.."))
		{
			routeName = backOneRoute(routeName);
			showDirectory(routeName);
		}
		
		else if(userStatementList.get(0).equals("dir..\\.."))
		{
			routeName = backOneRoute(routeName);
			routeName = backOneRoute(routeName);
			showDirectory(routeName);
		}
		
		else if(userStatementList.get(0).equals("dir\\"))
		{	
			routeName = "C:";
			showDirectory(routeName);
		}
	}
	
	// cd 명령문 실행 
	public void runDir(List<String> userStatementList,String routeName) throws IOException
	{
		// cd 뒤에 다른 명령어가 있을 때 
		if(userStatementList.get(1).equals(".."))
		{
			userStatementList.set(0, "dir..");
			userStatementList.remove(1);
			routeName = backOneRoute(routeName);
			showDirectory(routeName);
			return;
		}
		else if(userStatementList.get(1).equals("..\\.."))
		{
			userStatementList.set(0, "dir..\\..");
			userStatementList.remove(1);
			routeName = backOneRoute(routeName);
			routeName = backOneRoute(routeName);
			return;
		}

		else if(userStatementList.get(1).equals("\\"))
		{
			userStatementList.set(0, "dir\\");
			userStatementList.remove(1);
			routeName = "C:";
			showDirectory(routeName);
			return;
		}
		else
		{
			showDirectory(routeName);
		}
		
	}
	
	public void showDirectory(String routeName) throws IOException
	{
		int fileCount = 0;
		int fileByteSum = 0;
		int directoryCount = 0;
		File file = new File(routeName);
		
		File[] files = file.listFiles();
		
		view.showDirTop(file);
		
		if(file.exists())
		{
			for(File components : files)
			{
				view.showDirectoryFormat(components, components.isDirectory());
				if(components.isDirectory())
				{
					directoryCount++;
				}
				
				else
				{
					fileByteSum += components.length();
					fileCount++;
				}
			}	

			view.showDirBottom(fileCount, directoryCount, fileByteSum,file.getUsableSpace());
		}
		
		else
		{
			view.showDirNoFine();
		}
		view.showRoute(controller.routeName);
	}
	
	// 한칸 뒤로가기 
	public String backOneRoute(String routeName) throws IOException
	{
		int seperateIndex; 
		if(routeName.equals("C:")||routeName.equals("c:"))
		{
			return routeName;
		}

		seperateIndex = routeName.lastIndexOf(File.separator); 
		routeName = routeName.substring(0, seperateIndex);

		return routeName;
	}
}
