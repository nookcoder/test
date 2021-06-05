package controller;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.List;

import model.CmdModel;
import view.CmdView;

public class CopyStatement {
	
	private CmdView view;
	private CmdController controller;
	private CmdModel model;	
	
	
	public CopyStatement(CmdView view,CmdController controller, CmdModel model)
	{
		this.view = view;
		this.controller = controller;
		this.model = model;
	}
	
	// copy 명령문 실행 
	public void runCopyStatement(List<String> userStatementList)throws IOException
	{
		if(userStatementList.size() == 3)
		{
			// 같은경로에 복사할때 
			if(!userStatementList.get(1).contains(File.separator) && !userStatementList.get(2).contains(File.separator))
			{
				copyWithNoPath(userStatementList);
			}
			else if(userStatementList.get(1).contains(File.separator) && !userStatementList.get(2).contains(File.separator))
			{
				copyWithOriginalPath(userStatementList);
			}
			
			else if(userStatementList.get(1).contains(File.separator) && !userStatementList.get(2).contains(File.separator))
			{
				copyWithCopyPath(userStatementList);
			}
			// 경로가 모두 입력될때 
			else if(userStatementList.get(1).contains(File.separator) && userStatementList.get(2).contains(File.separator))
			{
				copyWithTwoPath(userStatementList);
			}
		}
		
		else if(userStatementList.size() == 1)
		{
			view.showErrorSyntax();
			view.showRoute(controller.routeName);
		}
	}
	
	// 복사 실행하기 f
	public void runCopy(String originalPath, String copyPath) throws IOException
	{
		// 복사할 파일이 존재할 때 
		if(model.isExistsFile(originalPath))
		{
			File originalFile = new File(originalPath);
			File copyFile = new File(copyPath);
			if(originalFile.isDirectory())
			{
				model.copyDirectory(originalFile,copyFile);				
			}
			
			else
			{
				model.copyFile(originalFile, copyFile);
			}
			view.showSuccessCopy();
			view.showRoute(controller.routeName);
		}
		
		//isDirectory 추가 
		
		// 복사파일이 없을 때 
		else
		{
			view.showNoExistsOriginalFile();
			view.showRoute(controller.routeName);
		}
	}
	
	// 경로가 없을 때 
	public void copyWithNoPath(List<String> userStatementList) throws IOException
	{
		String originalPath = controller.routeName + File.separator+userStatementList.get(1);
		String copyPath = controller.routeName + File.separator+userStatementList.get(2);
		runCopy(originalPath,copyPath);
	}
	
	// 복사해올 파일 경로만 일력됐을 때 
	public void copyWithOriginalPath(List<String> userStatementList)throws IOException
	{
		String originalPath = userStatementList.get(1);
		String copyPath = controller.routeName + File.separator+userStatementList.get(2);
		runCopy(originalPath,copyPath);
	}
	
	// 복사될 파일 경로만 입력됐을 때 
	public void copyWithCopyPath(List<String> userStatementList)throws IOException
	{
		String originalPath = controller.routeName + File.separator+userStatementList.get(1);
		String copyPath = userStatementList.get(2);
		runCopy(originalPath,copyPath);
	}
	
	// 경로 두개 입력 됐을 때 
	public void copyWithTwoPath(List<String> userStatementList)throws IOException
	{
		String originalPath = userStatementList.get(1);
		String copyPath = userStatementList.get(2);
		runCopy(originalPath,copyPath);
	}
//	
//	public String getFirstFilePath(List<String> userStatementList)
//	{
//		String allPath="";
//		int newPathStartIndex;
//		
//		for(int index=1;index < userStatementList.size();index++)
//		{
//			allPath += userStatementList.get(index);
//		}
//		
//		newPathStartIndex = allPath.lastIndexOf(":");
//		
//		return allPath.substring(0, newPathStartIndex-1);
//	}
//	
//	public String getSecondPath(List<String> userStatementList)
//	{
//		String allPath="";
//		int newPathStartIndex;
//		
//		for(int index=1;index < userStatementList.size();index++)
//		{
//			allPath += userStatementList.get(index);
//		}
//		
//		newPathStartIndex = allPath.lastIndexOf(":");
//		
//		return allPath.substring(newPathStartIndex-1, allPath.length());
//	
//	}
}
