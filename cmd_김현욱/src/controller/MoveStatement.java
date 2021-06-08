package controller;

import java.io.File;
import java.io.IOException;
import java.util.List;
import java.util.Scanner;

import model.CmdModel;
import model.Constants;
import model.Copy;
import view.CmdView;

public class MoveStatement {
	private CmdView view;
	private CmdController controller;
	private CmdModel model;	
	private Copy copy; 
	private Scanner scan; 
	private Constants constants;
	
	public MoveStatement(CmdView view,CmdController controller,CmdModel model)
	{
		this.view = view;
		this.controller = controller;
		this.model = model;
		this.copy = new Copy();
		this.scan = new Scanner(System.in);
		this.constants = new Constants();
	}
	
	// copy 명령문 실행 
	public void runMoveStatement(List<String> userStatementList) throws IOException
	{
		if(userStatementList.size() == 3)
		{
			runMove(userStatementList);
		}
		
		else if(userStatementList.size() == 1)
		{
			view.showErrorSyntax();
			view.showRoute(controller.routeName);
		}
	}
	
	public void runMove(List<String> userStatementList) throws IOException
	{
		String sourcePath = model.makeCopyPathName(controller.routeName,userStatementList.get(1));
		String movePath = model.makeCopyPathName(controller.routeName,userStatementList.get(2));

		
		File source = new File(sourcePath); 
		File destination = new File(movePath);
		
		int catagory = model.checkCatagory(source, destination);
		
		switch(catagory)
		{
			//case constants.FILE_FILE:
			case 0:
				view.showNoExistsOriginalFile();
				view.showRoute(controller.routeName);
				break;
			case 1: // File_File
				moveFileToFile(sourcePath,movePath,userStatementList);
				break;
				
			case 2: // File_Directory
				moveFileToDirectory(sourcePath,movePath,userStatementList);
				break;
				
			case 3: // Directory_File
				view.showFailExcess();
				view.showSuccessMove(0);
				view.showRoute(controller.routeName);
				break;
				
			case 4: // Directory_Directory
				break;
		}
	}
	
	public void moveFileToFile(String sourcePath, String copyPath,List<String> userStatementList) throws IOException
	{
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		
		if(sourcePath.equals(copyPath))
		{
			view.showSuccessMove(1);
			view.showRoute(controller.routeName);
			return;
		}
		
		if(destination.exists())
		{
			String answer = constants.INITIALIZATION_STRING;
			while(answer.charAt(0) != 'y' && answer.charAt(0) != 'a' && answer.charAt(0) != 'n')
			{
				view.askOverWrite(copyPath);
				answer = scan.next().toLowerCase();
				
			}
			if(answer.charAt(0) == 'y' || answer.charAt(0) == 'a')
			{
				copy.FileToFile(source, destination);
				destination.delete();
				view.showSuccessMove(1);
				view.showRoute(controller.routeName);
				return;
			}
			
			else if(answer.charAt(0) == 'n')
			{
				view.showSuccessMove(1);
				view.showRoute(controller.routeName);
				return;
			}
		
		}
		
		copy.FileToFile(source, destination);
		source.delete();
		view.showSuccessMove(1);
		view.showRoute(controller.routeName);
	}
	
	public void moveFileToDirectory(String sourcePath, String copyPath,List<String> userStatementList) throws IOException
	{
		File source = new File(sourcePath); 
		File destination = new File(copyPath);
		String checkPath = copyPath + File.separator + source.getName();
		File check = new File(checkPath);
		if(check.exists())
		{
			String answer =constants.INITIALIZATION_STRING;
			while(answer.charAt(0) != 'y' && answer.charAt(0) != 'a' && answer.charAt(0) != 'n')
			{
				view.askOverWrite(checkPath);
				answer = scan.next().toLowerCase();
				
			}
			if(answer.charAt(0) == 'y' || answer.charAt(0) == 'a')
			{
				copy.FileToDirectory(source, destination);
				source.delete();
				view.showSuccessMove(1);
				view.showRoute(controller.routeName);
				return;
			}
			
			else if(answer.charAt(0) == 'n')
			{
				view.showSuccessMove(0);
				view.showRoute(controller.routeName);
				return;
			}
		}
		
		
		
		copy.FileToDirectory(source, destination);
		source.delete();
		view.showSuccessMove(1);
		view.showRoute(controller.routeName);
	}

}
