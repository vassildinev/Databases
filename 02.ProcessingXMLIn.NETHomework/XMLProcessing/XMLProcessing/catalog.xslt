<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <xsl:for-each select="catalog/album">
          <div style="border:1px solid black;border-radius:5px;background:#AAD;margin:20px;width:400px;">
            <h1>
              <em>
                <xsl:value-of select="name"/>
              </em>
            </h1>
            <hr/>
            <h3>
              Producer: <xsl:value-of select="producer"/>
            </h3>
            <h3>
              Year: <xsl:value-of select="year"/>
            </h3>
            <h4>
              Price: $<xsl:value-of select="price"/>
            </h4>
            <div style="border:1px solid black;margin:5px;">
              <strong>Songs</strong>
              <hr/>
              <br/>
              <xsl:for-each select="songs/song">
                <em>Title: </em> <xsl:value-of select="title"/>
                <br/>
              </xsl:for-each>
            </div>
          </div>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>