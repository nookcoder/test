import java.awt.EventQueue;

import Controller.SignUpController;
import model.MemberDataBase;
import view.SignUp;

public class BeginSignUpProject {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					SignUp frame = new SignUp();
					MemberDataBase member = new MemberDataBase();
					SignUpController controller = new SignUpController(member, frame);
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

}
