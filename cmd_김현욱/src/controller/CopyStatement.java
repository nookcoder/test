package controller;

import java.io.File;
import java.io.IOException;
import java.util.List;
import java.util.Scanner;

import model.CmdModel;
import model.Constants;
import model.Copy;
import view.CmdView;

public class CopyStatement {
	
	private CmdView view;
	private CmdController controller;
	private CmdModel model;
	private Copy copy; 
	private Constants constants;
	
	
	public CopyStatement(CmdView view,CmdController controller, CmdModel model, Constants constants)
	{
		this.view = view;
		this.controller = controller;
		this.model = model;
		this.constants = constants;
		this.copy = new Copy();
	}
	
	// copy 명령문 실행 
	public void runCopyStatement(List<String> userStatementList)throws IOException
	{
		if(userStatementList.size() == 3)
		{
			runCopy(userStatementList);
		}
		
		else if(userStatementList.size() == 1)
		{
			view.showErrorSyntax();
			view.showRoute(controller.routeName);
		}
	}
	
	public String makeCopyPathName(String currentRoute, String inputPath)
	{
		if(!inputPath.contains("C:"))
		{
			inputPath = currentRoute+ File.separator + inputPath;  
		}
		
		return inputPath;
	}
	
	public void runCopy(List<String> userStatementList) throws IOException
	{
		String sourcePath = makeCopyPathName(controller.routeName,userStatementList.get(1));
		String copyPath = makeCopyPathName(controller.routeName,userStatementList.get(2));
		
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		
		int catagory = model.checkCatagory(source, destination);
		
		switch(catagory)
		{
			//case constants.FILE_FILE:
			case 0:
				//view.showNoExistsOriginalFile();
				view.showRoute(controller.routeName);
				break;
			case 1: // File_File
				copyFileToFile(sourcePath,copyPath,userStatementList);
				break;
				
			case 2: // File_Directory
				copyFileToDirectory(sourcePath,copyPath);
				break;
				
			case 3: // Directory_File
				copyDirectoryToFile(sourcePath,copyPath);
				break;
				
			case 4: // Directory_Directory
				copyDirectoryToDirectory(sourcePath,copyPath);
				break;
		}
	}
	
	public void copyFileToFile(String sourcePath, String copyPath,List<String> userStatementList) throws IOException
	{
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		
		if(sourcePath.equals(copyPath))
		{
			view.showFailCopy();
			view.showRoute(controller.routeName);
			return;
		}
		
		if(destination.exists())
		{
			Scanner scan = new Scanner(System.in);
			String answer;
			view.askOverWrite(userStatementList.get(2));
			answer = scan.next().toLowerCase();
			if(answer.charAt(0) == 'y' || answer.charAt(0) == 'a')
			{
				copy.FileToFile(source, destination);
				view.showSuccessCopy();
				view.showRoute(controller.routeName);
				return;
			}
			
			else if(answer.charAt(0) == 'n')
			{
				view.showNumberOfCopy(0);
				view.showRoute(controller.routeName);
				return;
			}
		
		}
		
		copy.FileToFile(source, destination);
		view.showSuccessCopy();
		view.showRoute(controller.routeName);
	}
	
	public void copyFileToDirectory(String sourcePath, String copyPath) throws IOException
	{
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		
		copy.FileToDirectory(source, destination);
		view.showSuccessCopy();
		view.showRoute(controller.routeName);
	}
	
	public void copyDirectoryToFile(String sourcePath, String copyPath) throws IOException
	{
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		
		copy.DirectoryToFile(source,destination);
		view.showSuccessCopy();
		view.showRoute(controller.routeName);
	}
	
	public void copyDirectoryToDirectory(String sourcePath, String copyPath) throws IOException
	{
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		
		copy.DirectoryToDirectory(source,destination);
		view.showSuccessCopy();
		view.showRoute(controller.routeName);
	}
	

	

}
