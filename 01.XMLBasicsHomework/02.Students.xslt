<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Academy Students</h1>
        <table border="2" style="border-collapse:collapse">
          <tr bgcolor="#CCABFF">
            <th style="text-align:left">Name</th>
            <th style="text-align:left">Sex</th>
            <th style="text-align:left">Birth date</th>
            <th style="text-align:left">Phone</th>
            <th style="text-align:left">Course</th>
            <th style="text-align:left">Specialty</th>
            <th style="text-align:left">Faculty number</th>
            <th style="text-align:left">Enrollment</th>
            <th style="text-align:left">Exams</th>
            <th style="text-align:left">Teacher endorsements</th>
          </tr>
          <xsl:for-each select="academy/student">
            <tr>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="sex"/>
              </td>
              <td>
                <xsl:value-of select="birth-date"/>
              </td>
              <td>
                <xsl:value-of select="phone"/>
              </td>
              <td>
                <xsl:value-of select="course"/>
              </td>
              <td>
                <xsl:value-of select="specialty"/>
              </td>
              <td>
                <xsl:value-of select="faculty-number"/>
              </td>
              <td>
                <xsl:for-each select="enrollment/exam">
                  <div style="border:1px solid black;margin:2px;background:#F0000F;">
                    <b>Exam name: </b>
                    <xsl:value-of select="name"/>
                    <br/>
                    <b>Tutor: </b>
                    <xsl:value-of select="tutor"/>
                    <br/>
                    <b>Score: </b>
                    <xsl:value-of select="score"/>
                    <br/>
                  </div>
                </xsl:for-each>
              </td>
              <td>
                <xsl:for-each select="exams/exam">
                  <div style="border:1px solid black;margin:2px;background:#0FFFF0;">
                    <b>Exam name: </b>
                    <xsl:value-of select="name"/>
                    <br/>
                    <b>Tutor: </b>
                    <xsl:value-of select="tutor"/>
                    <br/>
                    <b>Score: </b>
                    <xsl:value-of select="score"/>
                    <br/>
                  </div>
                </xsl:for-each>
              </td>
              <td>
                <xsl:for-each select="teacher-endorsements/endorsement">
                  <div style="border:1px solid black;margin:2px;background:#A826C3;">
                    <b>Tutor: </b>
                    <xsl:value-of select="teacher"/>
                    <br/>
                    <b>Text: </b>
                    <xsl:value-of select="endorsement-text"/>
                    <br/>
                  </div>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>