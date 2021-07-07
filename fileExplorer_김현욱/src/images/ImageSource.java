package images;


import java.awt.Dimension;
import java.awt.Image;
import java.io.File;

import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.filechooser.FileSystemView;

public class ImageSource {

		ImageIcon backButtontemp = new ImageIcon("src/images/뒤로가기.png");
		ImageIcon forwardButtontemp = new ImageIcon("src/images/앞으로.png");
		Image backImage = setImageSize(backButtontemp,15,15);
		Image forwardButtonImage = setImageSize(forwardButtontemp,15,15);
		public ImageIcon backButton = new ImageIcon(backImage);
		public ImageIcon forwardButton = new ImageIcon(forwardButtonImage);
		
		public ImageIcon folderImageTemp = new ImageIcon("src/images/fileimage.png");
		public ImageIcon folderImage = new ImageIcon(setImageSize(folderImageTemp,60,60));
		
		public ImageIcon alertImageTemp = new ImageIcon("src/images/alert.png");
		public ImageIcon alertImage = new ImageIcon(setImageSize(alertImageTemp,50,50));
		
		private Image setImageSize(ImageIcon icon,int width,int height)
		{
			Image img = icon.getImage();
			Image changeImg = img.getScaledInstance(width,height, Image.SCALE_SMOOTH);
		
			return changeImg;
		}
}
