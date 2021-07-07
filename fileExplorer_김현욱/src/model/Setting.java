package model;

import java.awt.Dimension;
import java.awt.Image;
import java.io.File;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.filechooser.FileSystemView;

import images.ImageSource;

public class Setting {
	private ImageSource imgSource;
	
	public Setting(ImageSource imgSource) {
		this.imgSource = imgSource; 
	}
	// 아이콘 만들기 
	public JButton setIcon(File component) {
		
		String filename = component.getName();; 
		ImageIcon img;
		JButton aplication;
		// 파일모양 아이콘 만들기 
		if(component.isDirectory())
		{
			img = imgSource.folderImage; 
		}

		else
		{
			img = setIconimage(component);
		}

		aplication = new JButton(filename,img);
		setButton(aplication);
		aplication.setVerticalTextPosition(JButton.BOTTOM);
		aplication.setHorizontalTextPosition(JButton.CENTER);
		return aplication; 
	}
	
	// 아이콘 이미지 만들기 
	public ImageIcon setIconimage(File file)
	{
		ImageIcon rowIcon = (ImageIcon) FileSystemView.getFileSystemView().getSystemIcon(file); 
		Image changeIcon = rowIcon.getImage().getScaledInstance(60, 60, Image.SCALE_DEFAULT);
		ImageIcon icon = new ImageIcon(changeIcon);
		return icon;
	}

	// 버튼 설정 
	public void setButton(JButton btn)
	{
		btn.setBorderPainted(false);
		btn.setFocusPainted(false);
		btn.setContentAreaFilled(false);
		btn.setPreferredSize(new Dimension(100,100));
	}
}
