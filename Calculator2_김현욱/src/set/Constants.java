package set;
import java.awt.*;

import javax.swing.JButton;

public class Constants {

	public GridLayout textGridLayout = new GridLayout(0,1); 
	public GridLayout panelGridLayout = new GridLayout(0,2); 
	public BorderLayout KeyPadBorderLayout = new BorderLayout();
	public Font ButtonFont = new Font("µ¸À½", Font.BOLD, 20);
	public Font calculatorDisplayFont = new Font("µ¸À½",Font.BOLD,50);
	public Font calculatorDisplayFont2 = new Font("µ¸À½",Font.BOLD,45);
	public Font calculatorDisplayFont3 = new Font("µ¸À½",Font.BOLD,40);
	public Font calculatorDisplayFont4 = new Font("µ¸À½",Font.BOLD,38);
	public Font calculatorDisplayFont5 = new Font("µ¸À½",Font.BOLD,36);
	public Font calculatorDisplayFont6 = new Font("µ¸À½",Font.BOLD,34);
	public Font calculatorDisplayFont7 = new Font("µ¸À½",Font.BOLD,32);
	
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
}
