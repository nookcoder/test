package view;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.text.DecimalFormat;
import java.text.SimpleDateFormat;

public class CmdView {

	public void showWindowsVersion() throws IOException {
		Process process = Runtime.getRuntime().exec("cmd");
		InputStream inputStream = process.getInputStream();
		BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
		System.out.println(reader.readLine());
		System.out.println("(c) Microsoft Corporation. All rights reserved.");
		System.out.print("\n");
	}
	
	// 경로를 찾을 수 없을 떄 안내문 
	public void showNoFindRoute()
	{
		System.out.println("지정된 경로를 찾을 수 없습니다."); 
		System.out.print("\n");
	}
	
	// 명령문이 틀렸을 때 안내문 
	public void showErrorStatement(String statement) {
		System.out.println("'"+statement+"'"+"은(는) 내부 또는 외부명령, 실행할 수 있는 프로그램, 또는");
		System.out.println("배치 파일이 아닙니다.");
		System.out.print("\n");
	}
	
	public void showErrorConstruction()
	{
		System.out.println("파일 이름, 디렉터리 이름 또는 볼륨 레이블 구문이 잘못되었습니다.");
		System.out.print("\n");
	}
	
	public void showErrorSyntax()
	{
		System.out.println("명령 구문이 올바르지 않습니다.");
		System.out.print("\n");
	}
	
	public void showDeniedAccess()
	{
		System.out.println("액세스가 거부되었습니다.");
		System.out.print("\n");
	}
	
	// 현재 경로 보여주기 
	public void showRoute(String route) {
		System.out.print(route + ">");
	}
	
	public void showVolumeNumber()
	{
		System.out.println(" C 드라이브의 볼륨에는 이름이 없습니다.");
		System.out.println(" 볼륨 일련 번호 :BEBF-2222D");
	}
	
	// 파일디렉터리 출력
	public void showDirTop(String file) throws IOException
	{
		System.out.print("\n");
		System.out.println(" "+file+" 디렉터리");
		System.out.print("\n");
	}
	
	// dir 실행 시 출력 포멧 
	public void showDirectoryFormat(File file,boolean isDirectory)
	{
		SimpleDateFormat dataFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		System.out.print(dataFormat.format(file.lastModified()));
		if(isDirectory)
		{
			System.out.print("    <DIR>");
			System.out.print("          ");
			System.out.print(file.getName()+"\n");
		}
		
		else
		{
			System.out.print("         ");
			System.out.printf("%9d ",file.length());
			System.out.print(file.getName()+"\n");
		}
	}
	
	public void showDirBottom(int fileCount,int directoryCount,int fileByteSum,long directoyByte)
	{
		DecimalFormat decimalFormate = new DecimalFormat("###,###");
		String fileByteString = decimalFormate.format(fileByteSum);
		String directoryByteString = decimalFormate.format(directoyByte);
		System.out.printf("%16d개 파일%20s 바이트\n",fileCount,fileByteString);
		System.out.printf("%16d개 디렉터리%20s 바이트\n",directoryCount,directoryByteString);
		System.out.print("\n");
	}
	
	public void showDirNoFine()
	{
		System.out.println("파일을 찾을 수 없습니다.");
		System.out.print("\n");
	}
	
	
	
}
