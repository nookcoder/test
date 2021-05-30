package view;


import java.awt.event.*;

import javax.swing.*;

import model.Constants;

import javax.swing.JTextField;
import java.awt.*;
import javax.swing.JLabel;
import java.awt.geom.Area;
import java.awt.geom.*;

import javax.swing.SwingConstants;
import javax.swing.*;

public class LoginView extends JFrame{

	private Constants constants;
	private JPanel contentPanel;

	public LoginView(){
		setUndecorated(true);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(800,597);
		setLocationRelativeTo(null);

		this.constants = new Constants();

		contentPanel = new JPanel() {
			public void paintComponent(Graphics g) {
				Dimension demension = getSize();
				Image background = constants.LOGIN_BACKGROUND.getImage();
				g.drawImage(background, 0, 0,demension.width,demension.height,null);
				setOpaque(false);
				super.paintComponent(g);
			}
		};

		add(contentPanel);
		setVisible(true);
	}
}

