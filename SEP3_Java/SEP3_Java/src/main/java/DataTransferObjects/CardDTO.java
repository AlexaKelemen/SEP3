/*
package DataTransferObjects;

import Entities.Card;
import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonGetter;

import java.sql.Date;

public class CardDTO
{
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private int cardId;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String cardNumber;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String expirationDate;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String cvc;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String fName;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String lName;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String username;

  public CardDTO()
  {
  }
  public CardDTO(Card card)
  {
    this.cardId = card.getCardId();
    this.cardNumber = card.getCardNumber();
    this.expirationDate = convertSqlDate(card.getExpirationDate());
    this.cvc = card.getCvc();
    this.fName = card.getFName();
    this.lName = card.getLName();
    this.username = card.getUsername();
  }

  @JsonGetter("cardid")
  public int getCardId() {
    return cardId;
  }

  public void setCardId(int cardId) {
    this.cardId = cardId;
  }

  @JsonGetter("cardnumber")
  public String getCardNumber() {
    return cardNumber;
  }

  public void setCardNumber(String cardNumber) {
    this.cardNumber = cardNumber;
  }
  @JsonGetter("expirationdate")
  public String getExpirationDate() {
    return expirationDate;
  }

  public void setExpirationDate(Date expirationDate) {
    this.expirationDate = convertSqlDate(expirationDate);
  }


  @JsonGetter("cvc")
  public String getCvc() {
    return cvc;
  }

  public void setCvc(String cvc) {
    this.cvc = cvc;
  }

  @JsonGetter("fname")
  public String getFName() {
    return fName;
  }

  public void setFName(String fName) {
    this.fName = fName;
  }

  @JsonGetter("lname")
  public String getLName() {
    return lName;
  }

  public void setLName(String lName) {
    this.lName = lName;
  }
  @JsonGetter("username")
  public String getUsername() {
    return username;
  }

  public void setUsername(String username) {
    this.username = username;
  }

  private String convertSqlDate(Date date)
  {

    return date.toString();
  }



  public Card toCard()
  {
    Date expirationDate = new Date()
    Card returnCard = new Card(cardId, cardNumber, expirationDate, cvc, fName, lName, username);
  }
}
*/
