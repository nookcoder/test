package view.components;

import javax.swing.*;

public class ImageButton extends JButton {
    public ImageButton(ImageIcon image){
        setBorderPainted(false);
        setContentAreaFilled(false);
        setFocusPainted(false);
        setOpaque(false);
        setIcon(image);
    }
}
