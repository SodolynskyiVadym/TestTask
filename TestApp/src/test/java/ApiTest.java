import io.restassured.RestAssured;
import io.restassured.http.ContentType;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.*;


public class ApiTest {

    @BeforeAll
    public static void setup() {
        RestAssured.baseURI = "http://localhost";
        RestAssured.port = 5238;
    }

    @Test
    public void createValidUser_shouldReturn201() {
        String userJson = """
            {
              "fullName": "Test User",
              "email": "test123@example.com",
              "dateOfBirth": "1990-01-01"
            }
            """;

        given()
                .contentType(ContentType.JSON)
                .body(userJson)
                .when()
                .post("/users")
                .then()
                .statusCode(201)
                .body(containsString("User was created successfully"));
    }

    @Test
    public void createInvalidUser_withBadEmail_shouldReturn400() {
        String userJson = """
            {
              "fullName": "Invalid Email",
              "email": "invalid-email",
              "dateOfBirth": "1990-01-01"
            }
            """;

        given()
                .contentType(ContentType.JSON)
                .body(userJson)
                .when()
                .post("/users")
                .then()
                .statusCode(400)
                .body(containsString("Invalid user data"));
    }

}
