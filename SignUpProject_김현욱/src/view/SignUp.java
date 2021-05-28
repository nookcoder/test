package view;

import java.awt.Color;
import java.awt.event.ActionListener;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.AbstractBorder;
import javax.swing.border.EmptyBorder;

import model.Constants;

import javax.swing.JTextField;
import java.awt.*;
import javax.swing.JLabel;
import java.awt.geom.Area;
import java.awt.geom.*;

import javax.swing.SwingConstants;
import javax.swing.*;

public class SignUp extends JFrame {

	private Constants constants = new Constants();
	private JPanel contentPane;
	public JTextField idField;
	public JTextField passwordField;
	public JTextField passwordCheckField;
	public JTextField nameField;
	public JTextField birthField;
	public JTextField phoneNumberField;
	public JTextField emailField;
	public JTextField addressField;

	public SignUp() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(400,600);
		setResizable(false);
		setLocationRelativeTo(null);
		
		contentPane = new JPanel() {
			public void paintComponent(Graphics g)
			{
				Dimension dimension = getSize();
				Image background = constants.SIGNUP_BACKGROUND.getImage();
				g.drawImage(background, 0, 0, dimension.width,dimension.height,null);
				setOpaque(false);
				super.paintComponent(g);
			}
		};
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel idLabel = new JLabel("아이디 :  ");
		idLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		idLabel.setFont(constants.SIGNUP_FONT);
		idLabel.setBounds(31, 23, 71, 51);
		idLabel.setForeground(constants.YELLOW);
		contentPane.add(idLabel);
		
		JLabel passwordLabel = new JLabel("비밀번호 : ");
		passwordLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		passwordLabel.setFont(constants.SIGNUP_FONT);
		passwordLabel.setBounds(31, 84, 71, 51);
		passwordLabel.setForeground(constants.YELLOW);
		contentPane.add(passwordLabel);
		
		JLabel passwordCheckLabel = new JLabel("비밀번호 확인 : ");
		passwordCheckLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		passwordCheckLabel.setFont(constants.SIGNUP_FONT);
		passwordCheckLabel.setBounds(-1, 145, 103, 51);
		passwordCheckLabel.setForeground(Color.RED);
		contentPane.add(passwordCheckLabel);
		
		JLabel nameLabel = new JLabel("이름 : ");
		nameLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		nameLabel.setFont(constants.SIGNUP_FONT);
		nameLabel.setBounds(31, 206, 71, 51);
		nameLabel.setForeground(constants.YELLOW);
		contentPane.add(nameLabel);
		
		JLabel birthLabel = new JLabel("생년월일 : ");
		birthLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		birthLabel.setFont(constants.SIGNUP_FONT);
		birthLabel.setBounds(31, 267, 71, 51);
		birthLabel.setForeground(constants.YELLOW);
		contentPane.add(birthLabel);
		
		JLabel phoneNumberLabel = new JLabel("전화번호 : ");
		phoneNumberLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		phoneNumberLabel.setFont(constants.SIGNUP_FONT);
		phoneNumberLabel.setBounds(31, 328, 71, 51);
		phoneNumberLabel.setForeground(constants.YELLOW);
		contentPane.add(phoneNumberLabel);
		 
		JLabel emailLabel = new JLabel("이메일 : ");
		emailLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		emailLabel.setFont(constants.SIGNUP_FONT);
		emailLabel.setForeground(constants.YELLOW);
		emailLabel.setBounds(43, 389, 59, 51);
		contentPane.add(emailLabel);
		
		JLabel addressLabel = new JLabel("주소 : ");
		addressLabel.setHorizontalAlignment(SwingConstants.TRAILING);
		addressLabel.setFont(constants.SIGNUP_FONT);
		addressLabel.setBounds(43, 450, 59, 53);
		addressLabel.setForeground(constants.YELLOW);
		contentPane.add(addressLabel);
		
		idField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		idField.setBounds(114, 30, 225, 36);
		idField.setColumns(10);
		idField.setBackground(constants.LIGHE_BLUE);
		idField.setForeground(Color.WHITE);
		idField.setFont(constants.SIGNUP_FONT);
		contentPane.add(idField);
		
		passwordField = new JPasswordField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		passwordField.setColumns(10);
		passwordField.setBounds(114, 92, 225, 36);
		passwordField.setBackground(constants.LIGHE_BLUE);
		passwordField.setForeground(Color.WHITE);
		contentPane.add(passwordField);
		
		passwordCheckField = new JPasswordField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		passwordCheckField.setColumns(10);
		passwordCheckField.setBounds(114, 153, 225, 36);
		passwordCheckField.setBackground(constants.LIGHE_BLUE);
		passwordCheckField.setForeground(Color.WHITE);
		contentPane.add(passwordCheckField);
		
		nameField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		nameField.setColumns(10);
		nameField.setBounds(114, 221, 225, 36);
		nameField.setBackground(constants.LIGHE_BLUE);
		nameField.setForeground(Color.WHITE);
		nameField.setFont(constants.SIGNUP_FONT);
		contentPane.add(nameField);
		
		birthField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		birthField.setColumns(10);
		birthField.setBounds(114, 274, 225, 36);
		birthField.setBackground(constants.LIGHE_BLUE);
		birthField.setForeground(Color.WHITE);
		birthField.setFont(constants.SIGNUP_FONT);
		contentPane.add(birthField);
		
		phoneNumberField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		phoneNumberField.setColumns(10);
		phoneNumberField.setBounds(114, 335, 225, 36);
		phoneNumberField.setBackground(constants.LIGHE_BLUE);
		phoneNumberField.setForeground(Color.WHITE);
		phoneNumberField.setFont(constants.SIGNUP_FONT);
		contentPane.add(phoneNumberField);
		
		emailField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		emailField.setColumns(10);
		emailField.setBounds(114, 396, 225, 36);
		emailField.setBackground(constants.LIGHE_BLUE);
		emailField.setForeground(Color.WHITE);
		emailField.setFont(constants.SIGNUP_FONT);
		contentPane.add(emailField);
		
		addressField = new JTextField() {
			@Override 
			protected void paintComponent(Graphics g) {
				if (!isOpaque() && getBorder() instanceof RoundedCornerBorder) {
					Graphics2D g2 = (Graphics2D) g.create();
					g2.setPaint(getBackground());
					g2.fill(((RoundedCornerBorder) getBorder()).getBorderShape(
							0, 0, getWidth() - 1, getHeight() - 1));
					g2.dispose();
				}
				super.paintComponent(g);
			}
			@Override 
			public void updateUI() {
				super.updateUI();
				setOpaque(false);
				setBorder(new RoundedCornerBorder());
			}
		};
		addressField.setColumns(10);
		addressField.setBounds(114, 458, 225, 36);
		addressField.setBackground(constants.LIGHE_BLUE);
		addressField.setForeground(Color.WHITE);
		addressField.setFont(constants.SIGNUP_FONT);
		contentPane.add(addressField);
		
		JButton okayButton = new JButton("OK") {
			@Override
			protected void paintComponent(Graphics g) {
				int width = getWidth();
				int height = getHeight();
				
				Graphics2D graphics = (Graphics2D) g;
				
				graphics.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
				
				if(getModel().isArmed()) {
					graphics.setColor(getBackground().darker());
				} else if (getModel().isRollover()) {
					graphics.setColor(getBackground().brighter());
				} else {
					graphics.setColor(getBackground());
				}
				
				graphics.fillRoundRect(0,0,width,height,15,15);
				
				FontMetrics fontMetrics = graphics.getFontMetrics(); 
				Rectangle stringBounds = fontMetrics.getStringBounds(this.getText(), graphics).getBounds();
				
				int textX = (width - stringBounds.width) / 2;
				int textY = (height - stringBounds.height) / 2 + fontMetrics.getAscent(); graphics.setColor(getForeground()); 
				
				graphics.setFont(getFont());
				graphics.drawString(getText(), textX, textY);
				graphics.dispose();

				super.paintComponent(g);
			}
		};
		okayButton.setBounds(161, 519, 91, 23);
		okayButton.setBackground(constants.LIGHE_BLUE);
		okayButton.setForeground(constants.YELLOW);
		contentPane.add(okayButton);
	}
	
	// 텍스트 필드 값 받아오기 
	public String getId() {
		return idField.getText();
	}
	public String getPassword() {
		return passwordField.getText();
	}
	public String getPasswordCheck() {
		return passwordCheckField.getText();
	}
	public String getName() {
		return nameField.getText();
	}
	public String getBirth() {
		return birthField.getText();
	}
	public String getPhoneNumber() {
		return phoneNumberField.getText();
	}
	public String getEmail() {
		return emailField.getText();
	}
	public String getAddress() {
		return addressField.getText();
	}

	// 이벤트 등록 
	public void setIdListener(ActionListener listener)
	{
		idField.addActionListener(listener);
	}
	public void setPasswordListener(ActionListener listener)
	{
		passwordField.addActionListener(listener);
	}
	public void setPasswordChekcListener(ActionListener listener)
	{
		passwordCheckField.addActionListener(listener);
	}
	public void setNameListener(ActionListener listener)
	{
		nameField.addActionListener(listener);
	}
	public void setBirthListener(ActionListener listener)
	{
		birthField.addActionListener(listener);
	}
	public void setPhoneNumberListener(ActionListener listener)
	{
		phoneNumberField.addActionListener(listener);
	}
	public void setEmailListener(ActionListener listener)
	{
		emailField.addActionListener(listener);
	}
	public void setAddressListener(ActionListener listener)
	{
		addressField.addActionListener(listener);
	}
	
	
	
	
	private class RoundedCornerBorder extends AbstractBorder {
		private Color ALPHA_ZERO = new Color(0x0, true);
		@Override 
		public void paintBorder(Component c, Graphics g, int x, int y, int width, int height) {
			Graphics2D g2 = (Graphics2D) g.create();
			g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
			Shape border = getBorderShape(x, y, width - 1, height - 1);
			g2.setPaint(ALPHA_ZERO);
			Area corner = new Area(new Rectangle2D.Double(x, y, width, height));
			corner.subtract(new Area(border));
			g2.fill(corner);
			g2.setPaint(Color.GRAY);
			g2.draw(border);
			g2.dispose();
		}
		public Shape getBorderShape(int x, int y, int w, int h) {
			int r = h; //h / 2;
			return new RoundRectangle2D.Double(x, y, w, h, r, r);
		}
		@Override public Insets getBorderInsets(Component c) {
			return new Insets(4, 8, 4, 8);
		}
		@Override public Insets getBorderInsets(Component c, Insets insets) {
			insets.set(4, 8, 4, 8);
			return insets;
		}
	}
	
}
