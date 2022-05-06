package model;

public class RecordVO {
    private String word;
    private String time;

    public RecordVO(String word, String time){
        this.word = word;
        this.time = time;
    }

    public String getWord() {
        return word;
    }

    public String getTime() {
        return time;
    }
}
