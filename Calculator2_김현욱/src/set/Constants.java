package set;
import java.awt.*;

import javax.swing.ImageIcon;
import javax.swing.JButton;

public class Constants {

	public GridLayout textGridLayout = new GridLayout(0,1); 
	public GridLayout panelGridLayout = new GridLayout(0,2); 
	public BorderLayout KeyPadBorderLayout = new BorderLayout();

	public Color RECORD_BACKGROUND = new Color(247,247,247);
	public Font RECORD_FONT = new Font("��������",Font.BOLD,30);
	
	public Font ButtonFont = new Font("����", Font.BOLD, 20);
	public Font calculatorDisplayFont = new Font("����",Font.BOLD,50);
	public Font calculatorDisplayFont2 = new Font("����",Font.BOLD,45);
	public Font calculatorDisplayFont3 = new Font("����",Font.BOLD,40);
	public Font calculatorDisplayFont4 = new Font("����",Font.BOLD,38);
	public Font calculatorDisplayFont5 = new Font("����",Font.BOLD,36);
	public Font calculatorDisplayFont6 = new Font("����",Font.BOLD,34);
	public Font calculatorDisplayFont7 = new Font("����",Font.BOLD,32);
	
	public void setButtonFont(JButton btn) {
		btn.setFont(ButtonFont);
		btn.setBorderPainted(false);
		btn.setBackground(Color.WHITE);
	}
	
	public void setOperatorButton(JButton btn) {
		btn.setFont(ButtonFont);
		btn.setBorderPainted(false);
		btn.setBackground(new Color(220,220,220));
	}
	
	public void setEqualButton(JButton btn)
	{
		btn.setFont(ButtonFont);
		btn.setBorderPainted(false);
		btn.setBackground(new Color(120,120,255));

	}
	public Dimension dimension = new Dimension(450,550);
	
	ImageIcon deleteBynImage = new ImageIcon("src/images/deleteButon.png");
	Image changSize = deleteBynImage.getImage().getScaledInstance(40,40, Image.SCALE_SMOOTH);
	public ImageIcon DELETE_IMAGE = new ImageIcon(changSize);
}
