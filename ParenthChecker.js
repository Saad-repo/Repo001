const lispStatement = "(abcs)(aa(sdf))a(a)";
console.log("Verifying parenth matching in: ", lispStatement);

// given a string containing Lisp statements, verify opening pareths match closing parenths

// Output:
//  true: when null, empty string, balanced parenths
//  false: when not matching parents exist
function parenthsMatch(statementString) {
    if (statementString === null) { 
        return true;
    }
    var stack = [];
    var statementChars = statementString.split('');

    for (var i = 0; i < statementChars.length; i++) {
        if (statementChars[i] === '(' || statementChars[i] === ')') {
            if (statementChars[i] === '(') {
                stack.push(statementChars[i]);
            } else {
                if (stack.length === 0) {
                    return false;
                }
                
                stack.pop(); // remove 1
                if (statementChars[i] != ')') {
                    return false;
                }
            }
        }
    }

    return true;
}

if (parenthsMatch(lispStatement))
{
    console.log("Yes, balanced parenths"); 
}
else
{
    console.log("Nope. Parenths are not balanced");
}