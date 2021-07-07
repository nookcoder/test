package view;

import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;

import images.ImageSource;

public class Alert extends JFrame{
	public JLabel alertMessage;
	private ImageSource imgSource; 
	public Alert()
	{
		this.imgSource = new ImageSource(); 
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(550,150);
		getContentPane().setLayout(null);
		
		JPanel panel = new JPanel();
		panel.setBackground(Color.WHITE);
		panel.setBounds(0, 0, 536, 70);
		getContentPane().add(panel);
		panel.setLayout(null);
		
		JLabel alertImage = new JLabel(imgSource.alertImage);
		alertImage.setBounds(12, 10, 50, 50);
		panel.add(alertImage);
		
		alertMessage = new JLabel("New label");
		alertMessage.setBounds(74, 10, 450, 50);
		panel.add(alertMessage);
		
		JPanel panel_1 = new JPanel();
		panel_1.setBounds(0, 69, 536, 34);
		getContentPane().add(panel_1);
		panel_1.setLayout(null);
		
		JButton btnNewButton = new JButton("확인");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				setVisible(false);
			}
		});
		btnNewButton.setBounds(457, 10, 67, 23);
		panel_1.add(btnNewButton);
		setVisible(true);
		
	}

	public void setMessageText(String path)
	{
		alertMessage.setText("<html>'" + path + "'을(를) 찾을 수 없습니다.<br />맞춤법을 확인하고 다시 시도하십시오.</html>");
	}
}
