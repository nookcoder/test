package controller;

import java.io.File;
import java.io.IOException;
import java.util.List;

import cmd_김현욱.Constants;
import model.CmdModel;
import view.CmdView;

public class DirStatement {
	private CmdView view;
	private CmdController controller;
	private CdStatement cd; 
	private CmdModel model;
	private Constants constants;
	
	public DirStatement(CmdView view, CmdController controller,CmdModel model,Constants constants)
	{
		this.view = view;
		this.controller = controller;
		this.model = model;
		this.constants = new Constants();
	}
	
	public void runDirStatement(List<String> userStatementList) throws IOException
	{
		String routeName = controller.routeName;
		String newRouteName;
		
		view.showVolumeNumber();
		
		if(userStatementList.get(constants.FIRST_COMMADN).equals("dir"))
		{
			if(userStatementList.size()>constants.ONE_TEXT)
			{
				for(int index=1;index < userStatementList.size(); index++)
				{
					runDir(userStatementList,routeName,index);
				}
				return;
			}
			showDirectory(routeName);
		}
		
		else if(userStatementList.get(constants.FIRST_COMMADN).equals("dir.."))
		{

			newRouteName = model.backOneRoute(routeName);
			showDirectory(newRouteName);
			
			repeatRunDir(userStatementList,routeName);
		}
		
		else if(userStatementList.get(constants.FIRST_COMMADN).equals("dir..\\.."))
		{
			newRouteName = model.backOneRoute(routeName);
			newRouteName = model.backOneRoute(newRouteName);
			showDirectory(newRouteName);
		
			repeatRunDir(userStatementList,routeName);
		}
		
		else if(userStatementList.get(constants.FIRST_COMMADN).equals("dir\\"))
		{	
			newRouteName = "C:";
			showDirectory(newRouteName);
			
			repeatRunDir(userStatementList,routeName);
		}
		
		view.showRoute(controller.routeName);
	}
	
	// dir 명령문 여러개 있을 떄 처리 
	public void repeatRunDir(List<String> userStatementList,String routeName) throws IOException
	{
		if(userStatementList.size()>constants.ONE_TEXT)
		{
			for(int index=1;index < userStatementList.size(); index++)
			{
				runDir(userStatementList,routeName,index);
			}
			return;
		}
	}

	
	//  dir 명령문 실행 
	public void runDir(List<String> userStatementList,String routeName,int index) throws IOException
	{
		
		// dir 뒤에 다른 명령어가 있을 때 
		if(userStatementList.get(index).equals(".."))
		{
			routeName = model.backOneRoute(routeName);
			showDirectory(routeName);
			return;
		}
		else if(userStatementList.get(index).equals("..\\.."))
		{
			routeName = model.backOneRoute(routeName);
			routeName = model.backOneRoute(routeName);
			return;
		}

		else if(userStatementList.get(index).equals("\\"))
		{
			showDirectory("C:");
			return;
		}
		
		else
		{
			showDirectory(routeName+File.separator+userStatementList.get(index).toString());
		}
		
	}
	
	public void showDirectory(String routeName) throws IOException
	{
		int fileCount = 0;
		int fileByteSum = 0;
		int directoryCount = 0;
		File file = new File(routeName);
		
		File[] files = file.listFiles();
		
		if(file.exists())
		{
			view.showDirTop(file.getCanonicalPath());
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
			view.showDirTop(controller.routeName);
			view.showDirNoFine();
		}
	}
}
